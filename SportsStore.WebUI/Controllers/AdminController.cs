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
    [Authorize]
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

        public ViewResult Delete(int? id)
        {
            //TODO: check by id

            repository.RemoveProduct(id.Value);

            return View("Index", repository.Products);
        }

        [HttpPost]
        public ActionResult Edit(int? id, string productName, string details, decimal price, string category, HttpPostedFileBase image = null)
        {
            Product product = repository.Products.FirstOrDefault(p => p.Id == id); ;
            if (ModelState.IsValid)
            {
                //edit product
                Category selectedCategory = repository.Categories.FirstOrDefault(c => c.Name == category);

                if (selectedCategory == null)
                {
                    TempData["message"] = $"\"{category}\" category was not found!";
                    return RedirectToAction("Index");
                }

                if(product == null) product = new Product();

                if(image != null)
                {
                    product.ImageMimeType = image.ContentType;
                    product.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(product.ImageData, 0, image.ContentLength);
                }
                product.ProductName = productName;
                product.Details = details;
                product.Price = price;
                product.CategoryId = selectedCategory.Id.Value;

                repository.SaveProduct(product);
                TempData["message"] = $"{product.ProductName} has been saved";
            }
            return RedirectToAction("Index");
        }

        public PartialViewResult Actions(string action = null)
        {
            ViewBag.SelectedAction = action;

            IEnumerable<string> actions = new List<string>()
            {
                "Product Management",
                "Statistic"
            };

            return PartialView(actions);
        }

    }
}