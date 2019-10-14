using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MehmetApp.MVCUI.Entity
{
    public class DataInitilializer : DropCreateDatabaseIfModelChanges<DataContext>

    {
        protected override void Seed(DataContext context)
        {
            

            var categories = new List<Category>()
            {
                new Category(){ Name="Kamera" ,Description="Kamera Ürünleri" },
                new Category(){ Name="Bilgisayar" ,Description="Bilgisayar Ürünleri" },
                new Category(){ Name="Telefon" ,Description="Telefon Ürünleri" },
                new Category(){ Name="Beyaz Eşya" ,Description="Beyaz Eşya Ürünleri" }
                
            };

            foreach (var category in categories)
            {
                context.Categories.Add(category);
            }

            context.SaveChanges();

            var products = new List<Product>()
            {

                new Product(){Name="Canon 1200D" , Description="Profesyonel Dijital kamera" , Price=2500 ,IsApproved=true,Stock=12,CategoryId=1,IsHome=true,Image="1.jpg"},
                new Product(){Name="Canon 700D" , Description="" , Price=3000 ,IsApproved=true,Stock=2,CategoryId=1,IsHome=true,Image="1.jpg"},
                new Product(){Name="Canon100D" , Description="Profesyonel Dijital kamera" , Price=1850 ,IsApproved=false,Stock=3,CategoryId=1,IsHome=true,Image="1.jpg"},

                new Product(){Name="Asus" , Description="Profesyonel PC" , Price=5600 ,IsApproved=false,Stock=22,CategoryId=2,Image="2.jpg"},
                new Product(){Name="Casper" , Description="Profesyonel PC" , Price=4500 ,IsApproved=false,Stock=32,CategoryId=2,Image="2.jpg"},
                new Product(){Name="Lenovo" , Description="Profesyonel PC" , Price=8000 ,IsApproved=true,Stock=33,CategoryId=2,IsHome=true,Image="2.jpg"},

                new Product(){Name="UĞUR Buzdolabı" , Description="Dayanıklı Beyaz Eşya" , Price=1500 ,IsApproved=true,Stock=33,CategoryId=4,Image="4.jpg"},
                new Product(){Name="Vestel b23" , Description="Dayanıklı Beyaz Eşya" , Price=2200 ,IsApproved=false,Stock=45,CategoryId=4,IsHome=true,Image="4.jpg"},
                new Product(){Name="Arelik F5672" , Description="Dayanıklı Beyaz Eşya" , Price=3000 ,IsApproved=true,Stock=55,CategoryId=4,IsHome=true,Image="4.jpg"},

                new Product(){Name="Iphone 7s" , Description="IphoneIphoneIphone" , Price=4000 ,IsApproved=true,Stock=10,CategoryId=3,IsHome=true,Image="3.jpg"},
                new Product(){Name="Samsung Galaxy S7" , Description="SamsungSamsungSamsung" , Price=2000 ,IsApproved=true,Stock=11,CategoryId=3,Image="3.jpg"},
                new Product(){Name="General Mobile One" , Description="GeneralMobileGeneralMobileGeneralMobile" , Price=2500 ,IsApproved=true,Stock=10,CategoryId=3,IsHome=true,Image="3.jpg"}

            };


            foreach (var item in products)
            {

                context.Products.Add(item);
                
            }

            context.SaveChanges();

            base.Seed(context);
        }

    }
}