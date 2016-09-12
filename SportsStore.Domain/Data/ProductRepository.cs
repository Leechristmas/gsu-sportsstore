using SportsStore.Domain.Contexts;
using SportsStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Data
{
    public class ProductRepository
    {
        private ProductContext context = new ProductContext();

        /// <summary>
        /// list of the products
        /// </summary>
        public IEnumerable<Product> Products => context.Products.Include(p => p.Category);

        /// <summary>
        /// list of the categories
        /// </summary>
        public IEnumerable<Category> Categories => context.Categories;

        /// <summary>
        /// list of the purchases
        /// </summary>
        public IEnumerable<Purchase> Purchases => context.Purchases;

        /// <summary>
        /// list of the users
        /// </summary>
        public IEnumerable<StoreUser> StoreUsers => context.StoreUsers;

        /// <summary>
        /// Save or update the product
        /// </summary>
        /// <param name="product">new or updated product</param>
        public void SaveProduct(Product product)
        {
            if (product.Id == null)
                context.Products.Add(product);
            else
            {
                Product dbEntry = context.Products.Find(product.Id);
                if(dbEntry != null)
                {
                    dbEntry.CategoryId = product.CategoryId;
                    dbEntry.Category = product.Category;
                    dbEntry.Details = product.Details;
                    dbEntry.Price = product.Price;
                    dbEntry.ProductName = product.ProductName;
                    dbEntry.ImageMimeType = product.ImageMimeType;
                    dbEntry.ImageData = product.ImageData;
                }
            }
            context.SaveChanges();
        }

        public void RegisterOrder(List<Purchase> order)
        {
            context.Purchases.AddRange(order);
            context.SaveChanges();
        }

        public void RegisterPurchase(Purchase purchase)
        {
            context.Purchases.Add(purchase);
            context.SaveChanges();
        }
        
        /// <summary>
        /// Save or update the category
        /// </summary>
        /// <param name="category">new or updated category</param>
        public void SaveCategory(Category category)
        {
            if (category.Id == null)
                context.Categories.Add(category);
            else
            {
                Category dbEntry = context.Categories.Find(category.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = category.Name;
                }
            }
            context.SaveChanges();
        }

        /// <summary>
        /// Save or update the store user 
        /// </summary>
        /// <param name="storeUser"></param>
        public void SaveStoreUser(StoreUser storeUser)
        {
            if (storeUser.Id == null)
                context.StoreUsers.Add(storeUser);
            else
            {
                StoreUser dbEntry = context.StoreUsers.Find(storeUser.Id);
                if(dbEntry != null)
                {
                    dbEntry.FirstName = storeUser.FirstName;
                    dbEntry.LastName = storeUser.LastName;
                    dbEntry.MobileNumber = storeUser.MobileNumber;
                    dbEntry.UserRegisterDate = storeUser.UserRegisterDate;
                    dbEntry.EmailAddress = storeUser.EmailAddress;
                }
            }
            context.SaveChanges();
        }
        
        /// <summary>
        /// Remove the category
        /// </summary>
        /// <param name="categoryId">removing category id</param>
        /// <returns></returns>
        public Category RemoveCategory(int categoryId)
        {
            Category dbEntry = context.Categories.Find(categoryId);
            if(dbEntry != null)
            {
                context.Categories.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        /// <summary>
        /// Remove the product
        /// </summary>
        /// <param name="productId">removing product id</param>
        /// <returns></returns>
        public Product RemoveProduct(int productId)
        {
            Product dbEntry = context.Products.Find(productId);
            if(dbEntry != null)
            {
                context.Products.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        
    }
}
