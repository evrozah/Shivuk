using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShivukMVC.Models
{
    public class Category
    {
        List<Products> categoryProducts = new List<Products>();
        public List<Products> CategoryProducts
        {
            get
            {
                return categoryProducts;
            }
        }
        public int CategoryID { get; set; }
        public string CategoryTitle { get; set; }

        

        public void AddProducts(Products p)
        {
            categoryProducts.Add(p);
        }
    }
}
