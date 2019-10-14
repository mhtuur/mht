using MehmetApp.MVCUI.Entity;
using MehmetApp.MVCUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MehmetApp.MVCUI.Controllers
{
    public class HomeController : Controller
    {

        DataContext _context = new DataContext();

        // GET: Home
        public ActionResult Index()
        {

            var product = _context.Products.Where(i => i.IsHome && i.IsApproved).Select(i=> new ProductModel()
            {
                Id=i.Id,
                Description=i.Description.Length>30?i.Description.Substring(0,47)+"...":i.Description,
                Image=i.Image,
                Name = i.Name.Length > 30 ? i.Name.Substring(0, 30) + "..." : i.Name,
                IsHome =i.IsHome,
                IsApproved=i.IsApproved,
                Price=i.Price,
                Stock=i.Stock,
                CategoryId=i.CategoryId
                
            }).ToList();

            return View(product);
        }

        public ActionResult Details (int id)
        {
            var product = _context.Products.Where(i => i.Id == id).FirstOrDefault();

            return View(product);
        }

        public ActionResult List()
        {

            var product = _context.Products.Where(i => i.IsApproved).Select(i => new ProductModel()
            {
                Id = i.Id,
                Description = i.Description.Length > 30 ? i.Description.Substring(0, 47) + "..." : i.Description,
                Image = i.Image,
                Name = i.Name.Length>30 ? i.Name.Substring(0,30)+"...":i.Name,
                IsHome = i.IsHome,
                IsApproved = i.IsApproved,
                Price = i.Price,
                Stock = i.Stock,
                CategoryId = i.CategoryId

            }).ToList();

            return View(product);
        }


    }
}