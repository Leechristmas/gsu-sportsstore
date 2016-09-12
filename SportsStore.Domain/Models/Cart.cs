using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Models
{
    /// <summary>
    /// User's cart
    /// </summary>
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        /// <summary>
        /// Adds new product to the cart
        /// </summary>
        /// <param name="product">product for adding</param>
        /// <param name="quantity">quantity of the product</param>
        public void AddItem(Product product, int quantity)
        {
            CartLine line = lineCollection.Where(p => p.Product.Id == product.Id)
                .FirstOrDefault();

            if (line == null)
                lineCollection.Add(new CartLine() { Product = product, Quantity = quantity });
            else
                line.Quantity += quantity;
        }

        /// <summary>
        /// Removes the product from the cart
        /// </summary>
        /// <param name="product">product for removing</param>
        public void RemoveLine(Product product)
        {
            lineCollection.RemoveAll(l => l.Product.Id == product.Id);
        }

        /// <summary>
        /// Computes the total price over the cart
        /// </summary>
        /// <returns>total price</returns>
        public decimal ComputeTotalPrice()
        {
            return lineCollection.Sum(p => p.Product.Price * p.Quantity);
        }

        /// <summary>
        /// Clears the cart
        /// </summary>
        public void Clear()
        {
            lineCollection.Clear();
        }

        /// <summary>
        /// Collection of the products from the cart
        /// </summary>
        public IEnumerable<CartLine> Lines => lineCollection;
    }

    public class CartLine
    {
        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
