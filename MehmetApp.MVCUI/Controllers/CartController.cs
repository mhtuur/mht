using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MehmetApp.MVCUI.Entity;
using MehmetApp.MVCUI.Models;

namespace MehmetApp.MVCUI.Controllers
{

    [Authorize(Roles = "user")]
    [Authorize(Roles = "admin")]
    public class CartController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Cart
        
        public ActionResult Index()
        {
            return View(GetCart());
        }

        public ActionResult AddToCart(int id)
        {

            var product = db.Products.FirstOrDefault(i => i.Id == id);

            if (product!=null)
            {

                GetCart().AddProduct(product,1);
                
            }


            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromCart(int id)
        {

            var product = db.Products.FirstOrDefault(i => i.Id == id);

            if (product != null)
            {

                GetCart().DeleteProduct(product);

            }


            return RedirectToAction("Index");
        }

        public Cart GetCart() // Current kullanıcıya sadece 1 defa cart vermek için gerekli
        {
            Cart cart = (Cart)Session["Cart"]; // Session her kullanıcıya özel oluşturulan bir depodur.

            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }

            return cart;
        }

        [ChildActionOnly]
        public PartialViewResult Summary() // sepet ikonunun yanında sepete eklenen ürün sayısını göstercek
        {
            return PartialView(GetCart());
        }


        public ActionResult CheckOut()
        {

            return View(new ShippingDetails());
        }

        [HttpPost]
        public ActionResult CheckOut(ShippingDetails entity)
        {

            // ilk önce kartımızı almamız lazım
            var cart = GetCart();

            if (cart.CartLines.Count==0)
            {
                //cartLines icinde hiç ürün yoksa modelstate ile bir hata döndürürüz.
                ModelState.AddModelError("UrunYokError","Sepette ürün bulunmamaktadır.");
                
            }

            if (ModelState.IsValid)// Modeldeki Annotationlar denetimden geçti mi ?Yani form eksiksiz dolduruldu tüm kurallarıyla.
            {
                // Siparişi veritabanına kaydedebiliriz.Sonrasında Cart'ı sıfırla

                SaveOrder(cart,entity); // ShippingDetails entity

                cart.Clear();
                return View("Completed");

            }
            else
            {
                return View(entity);
            }
            
        }

        private void SaveOrder(Cart cart, ShippingDetails entity)
        {

            var order = new Order();

            order.OrderNumber = "Z"+(new Random()).Next(111111,999999).ToString();
            order.Total = cart.TotalPrice();
            order.OrderDate = DateTime.Now;
            order.UserName = entity.UserName;
            order.AdresBasligi = entity.AdresBasligi;
            order.Adres = entity.Adres;
            order.Sehir = entity.Sehir;
            order.Semt = entity.Semt;
            order.Mahalle = entity.Mahalle;
            order.PostaKodu = entity.PostaKodu;

            order.Orderlines = new List<OrderLine>();

            foreach (var product in order.Orderlines)
            {
                var orderLine = new OrderLine();
                orderLine.Quantity = product.Quantity;
                orderLine.Price = product.Price*product.Quantity;
                orderLine.ProductId = product.ProductId;

                order.Orderlines.Add(orderLine);

            }

            db.Orders.Add(order);
            db.SaveChanges(); //OrderLines Tablosu Order ile ilişkili olduğundan otomatik o da oluştu.



        }
    }
}