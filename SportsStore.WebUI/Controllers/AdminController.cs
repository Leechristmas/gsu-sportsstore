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
                categories.Add(new SelectListItem() {Text = p.Name, Selected = product?.CategoryId == p.Id});
            });

            return View(new ProductViewModel() {Product = product, Categories = categories} );
        }

        [HttpPost]
        public ActionResult Edit(int? id, string productName, string details, decimal price, string category)
        {
            Product product = null;
            if (ModelState.IsValid)
            {
                product = repository.Products.FirstOrDefault(p => p.Id == id);
                Category selectedCategory = repository.Categories.FirstOrDefault(c => c.Name == category);

                if (selectedCategory == null)
                {
                    TempData["message"] = $"\"{category}\" category was not found!";
                    return RedirectToAction("Index");
                }
                if (product != null)
                {
                    product.ProductName = productName;
                    product.Details = details;
                    product.Price = price;
                    product.CategoryId = selectedCategory.Id.Value; 

                    repository.SaveProduct(product);
                    TempData["message"] = $"{product.ProductName} has been saved";
                }

                TempData["message"] = $"Failed! The Product was not found!";
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }

    }
}