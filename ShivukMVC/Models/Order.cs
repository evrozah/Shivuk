using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShivukMVC.Models
{
    public class Order
    {
        List<Products> orderProducts = new List<Products>();
        public List<Products> OrderProducts
        {
            get
            {
                return orderProducts;
            }
        }
        public int OrderNumber { get; set; }
        public DateTime OrderClosingDate { get; set; }
        public int Quantity { get; set; }
        public void AddProducts(Products p)
        {
            orderProducts.Add(p);
        }


    }
}
