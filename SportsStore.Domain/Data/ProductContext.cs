using SportsStore.Domain.Mapping;
using SportsStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Contexts
{
    
    public class ProductContext: DbContext
    {
        static ProductContext()
        {
            Database.SetInitializer<ProductContext>(null);
        }

        public ProductContext(): base("Name=ProductContext")
        {

        }

        /// <summary>
        /// list of the categories
        /// </summary>
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// list of the products
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// list of the purchases
        /// </summary>
        public DbSet<Purchase> Purchases { get; set; }
        
        /// <summary>
        /// list of the users
        /// </summary>
        public DbSet<StoreUser> StoreUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations
                .Add(new CategoryMap())
                .Add(new ProductMap())
                .Add(new PurchaseMap())
                .Add(new StoreUserMap());
        }
    }
}
