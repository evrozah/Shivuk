using Microsoft.AspNetCore.Mvc;
using ShivukMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShivukMVC.ViewComponents
{
    public class NavigationMenuViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Categories  cats = new Categories();
            return View(cats.GetAllProducts());
        }
    }
}
