﻿using SportsStore.Domain.Data;
using SportsStore.Domain.Models;
using SportsStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private ProductRepository repository;

        /// <summary>
        /// Count of the products in the page
        /// </summary>
        public int PageSize = 12;

        public ProductController()
        {
            repository = new ProductRepository();
        }

        // GET: Product
        public ViewResult List(string category, int page = 1, string searchItem = null)
        {
            Category currentCategory = repository.Categories.FirstOrDefault(c => c.Name == category);
            IEnumerable<Product> products = repository.Products;
            ViewBag.SearchQuery = searchItem;

            if (searchItem != null) products = products.Where(p => p.ProductName.IndexOf(searchItem, StringComparison.Ordinal) >= 0 || (new Regex(searchItem).Matches(p.Details).Count > 0));

            if (currentCategory == null)
                products = products
                    .OrderBy(p => p.Id)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize)
                    .ToList();
            else
                products = products
                    .Where(p => p.Category.Name == category)
                    .OrderBy(p => p.Id)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize)
                    .ToList();
            
            return View(new ProductsListViewModel()
            {
                Products = products,
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ? repository.Products.Count() : products.Count(i => i.Category.Name == category)
                },
                Categories = repository.Categories,
                CurrentCategory = currentCategory
            });
        }

        public FileContentResult GetImage(int id)
        {
            Product prod = repository.Products
                .FirstOrDefault(p => p.Id == id);

            var f = File(prod.ImageData, prod.ImageMimeType);

            if (prod != null)
                return File(prod.ImageData, prod.ImageMimeType);
            else
                return null;
        }

    }
}