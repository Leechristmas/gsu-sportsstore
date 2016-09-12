using SportsStore.Domain.Data;
using SportsStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private ProductRepository repository;

        public NavController()
        {
            repository = new ProductRepository();
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<Category> categories = repository.Categories;

            return PartialView(categories);
        }
    }
}