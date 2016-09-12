using SportsStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.WebUI.Models
{
    /// <summary>
    /// view-model for the product-view
    /// </summary>
    public class ProductsListViewModel
    {
        /// <summary>
        /// list of the products
        /// </summary>
        public IEnumerable<Product> Products { get; set; }

        /// <summary>
        /// list of the categories
        /// </summary>
        public IEnumerable<Category> Categories { get; set; }
        
        public Category CurrentCategory { get; set; }

        /// <summary>
        /// the information for the pagination
        /// </summary>
        public PagingInfo PagingInfo { get; set; }
    }
}