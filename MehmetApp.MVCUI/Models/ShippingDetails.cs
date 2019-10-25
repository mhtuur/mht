using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MehmetApp.MVCUI.Models
{
    public class ShippingDetails
    {
        
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen Adres Başliğini giriniz.")]
        public string AdresBasligi { get; set; }

        [Required(ErrorMessage = "Lütfen Adres giriniz.")]
        public string Adres { get; set; }

        [Required(ErrorMessage = "Lütfen Şehir giriniz.")]
        public string Sehir { get; set; }

        [Required(ErrorMessage = "Lütfen Semt giriniz.")]
        public string Semt { get; set; }

        [Required(ErrorMessage = "Lütfen Mahalle giriniz.")]
        public string Mahalle { get; set; }

        public string PostaKodu { get; set; }

    }
}