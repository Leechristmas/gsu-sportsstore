using SportsStore.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SportsStore.Domain.Models
{
    public class Product: Entity
    {
        /// <summary>
        /// The product name
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        public string ProductName { get; set; }

        /// <summary>
        /// Id of the category
        /// </summary>
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public decimal Price { get; set; }

        /// <summary>
        /// Information about the product
        /// </summary>
        [DataType(DataType.MultilineText)]
        public string Details { get; set; }

        /// <summary>
        /// the binary data of the product image
        /// </summary>
        public byte[] ImageData { get; set; }

        /// <summary>
        /// the type of the produt image
        /// </summary>
        public string ImageMimeType { get; set; }
    }
}
