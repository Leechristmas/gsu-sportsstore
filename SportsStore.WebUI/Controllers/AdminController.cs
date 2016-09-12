using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Data;
using SportsStore.Domain.Models;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class AdminController : Controller
    {
        ProductRepository repository;

        public AdminController()
        {
            repository = new ProductRepository();
        }

        // GET: Admin
        public ViewResult Index()
        {
            return View(repository.Products);
        }

        public ViewResult Edit(int? id)
        {
            Product product = repository.Products.FirstOrDefault(p => p.Id == id);
            List<SelectListItem> categories = new  List<SelectListItem>();

            repository.Categories.ToList().ForEach(p =>
            {
                categories.Add(new SelectListItem() {Text = p.Name});
            });

            return View(new ProductViewModel() {Product = product, Categories = categories} );
        }

        [HttpPost]
        public ActionResult Edit(string productName, string details, decimal price, string category)
        {
            Product product = null;
            if (ModelState.IsValid)
            {
               product = new Product();

                repository.SaveProduct(product);
                TempData["message"] = $"{product.ProductName} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }

    }
}