using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MehmetApp.MVCUI.Entity
{
    public class Product
    {
        public int Id { get; set; }
        [DisplayName("Ürün Adı")]
        public string Name { get; set; }
        [DisplayName("Açıklama")]
        public string Description { get; set; }
        [DisplayName("Fiyat")]
        public double Price { get; set; }
        [DisplayName("Resim")]
        public string Image { get; set; }
        [DisplayName("Stok Adedi")]
        public int Stock { get; set; }
        [DisplayName("Onay")]
        public bool IsApproved { get; set; }
        [DisplayName("Anasayfa")]
        public bool IsHome { get; set; }
        
        public Category Category { get; set; }
        [DisplayName("Kategori")]
        public int CategoryId { get; set; } //Foreign Key For Nullable=> public int?

    }
}