﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace MehmetApp.MVCUI.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }

        public string UserName { get; set; }

        
        public string AdresBasligi { get; set; }
        public string Adres { get; set; }
        public string Sehir { get; set; }
        public string Semt { get; set; }
        public string Mahalle { get; set; }
        public string PostaKodu { get; set; }

        public virtual List<OrderLine> Orderlines { get; set; } //lazy loading kavramını kullanmak için virtual keyword'ünü kullandık.'
    }

    public class OrderLine
    {
        public int Id { get; set; }

        public int OrderId { get; set; }//foreign key
        public virtual Order Order { get; set; } 

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int Quantity { get; set; }
        public double Price { get; set; } // Ürünün o gün alınan fiyatı
    }

}