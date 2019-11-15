using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShivukMVC.Models;

namespace ShivukMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Categories categories=(Categories)HttpContext.RequestServices.GetService(typeof(Categories));
            return PartialView(categories.GetAllProducts());
        }

        public IActionResult Orders()
        {
            Orders orders = (Orders)HttpContext.RequestServices.GetService(typeof(Orders));
            return PartialView(orders.GetAllOrders());
        }
        public IActionResult Category(string categoryID)
        {
            Products products = (Products)HttpContext.RequestServices.GetService(typeof(Products));
            return PartialView(products.GetProductsByCategory(int.Parse(categoryID)));
        }
        public IActionResult Category2(int categoryID)
        {
            Products products = (Products)HttpContext.RequestServices.GetService(typeof(Products));
            return View(products.GetProductsByCategory(categoryID));
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
