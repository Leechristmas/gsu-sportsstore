using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsStore.Domain.Contexts;
using System.Collections;
using SportsStore.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using SportsStore.Domain.Data;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class DbOperationsTests
    {
        private ProductRepository repository = new ProductRepository();

        [TestMethod]
        [Description("Receiving categories")]
        public void GetAllCategories()
        {
            IEnumerable<Category> categories = null;

            categories = repository.Categories;

            Assert.IsNotNull(categories, "the list of the categories is null");
            Assert.IsTrue(categories.Count() > 0, "the list of the categories is empty");
        }

        [TestMethod]
        [Description("Receiving products")]
        public void GetAllProducts()
        {
            IEnumerable<Product> products = null;
                        
            products = repository.Products.ToList();

            Assert.IsNotNull(products, "the list of the products is null");
            Assert.IsTrue(products.Count() > 0, "the list of the products is empty");
        }

        [TestMethod]
        [Description("Receiving purchases")]
        public void GetAllPurchases()
        {
            IEnumerable<Purchase> purchases = null;

            purchases = repository.Purchases;

            Assert.IsNotNull(purchases, "the list of the purchases is null");
            //Assert.IsTrue(purchases.Count() > 0, "the list of the purchases is empty");
        }

        [TestMethod]
        [Description("Receiving store users")]
        public void GetAllStoreUsers()
        {
            IEnumerable<StoreUser> storeUsers = null;

            storeUsers = repository.StoreUsers;

            Assert.IsNotNull(storeUsers, "the list of the store users is null");
        }

        [TestMethod]
        [Description("Add-on a product and removing that")]
        public void AddAndRemoveProduct()
        {
            var product = new Product()
            {
                ProductName = "Barbell 600kg",
                Price = 22.5m,
                CategoryId = 4,
                Details = "the greatest barbell 600 kg"
            };

            repository.SaveProduct(product);

            var id = product.Id;

            Assert.IsNotNull(id);

            repository.RemoveProduct(id.Value);            
        }


    }
}
