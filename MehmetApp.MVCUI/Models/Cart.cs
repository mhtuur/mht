﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MehmetApp.MVCUI.Entity;

namespace MehmetApp.MVCUI.Models
{
    // cart = sepet'in tamamını temsil ediyor.'
    public class Cart
    {
        private List<CartLine> _cartLines = new List<CartLine>();

        // Get metodunu yazalım
        public List<CartLine> CartLines
        {
            get { return _cartLines; }
        }


        public void AddProduct(Product product, int quantity)
        {
            var line = _cartLines.FirstOrDefault(i => i.Product.Id==product.Id);

            if (line == null)
            {
               CartLines.Add(new CartLine(){Product = product,Quantity = quantity});
            }
            else
            {
                line.Quantity+=quantity;
            }

        }

        public void DeleteProduct(Product product)
        {

            var line = _cartLines.RemoveAll(i => i.Product.Id == product.Id);


        }

        public double TotalPrice()
        {
            
            return _cartLines.Sum(i=>i.Product.Price*i.Quantity);
        }

        public void Clear()
        {
            _cartLines.Clear();
        }

    }

    public class CartLine // Herbir ürünü temsil eden obje. Yani Alışveriş sepetindeki bir satır.
    {

        public Product Product { get; set; }
        public int Quantity { get; set; }

    }

}