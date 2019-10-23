using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ShivukMVC.Models
{
    public class Product
    {
        public string ProductID { get; set; }
        public string HebrewTitle { get; set; }
        public int Quantity { get; set; }
        public string EnglishTitle { get; set; }
        public string PictureLink { get; set; }
        public int CategoryID { get; set; }
        public string CategoryTitle { get; set; }
        public string Description { get; set; }
    }
}
