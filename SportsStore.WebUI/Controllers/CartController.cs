using SportsStore.Domain.Data;
using SportsStore.Domain.Models;
using SportsStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        private ProductRepository repository;

        public CartController()
        {
            repository = new ProductRepository();
        }

        /// <summary>
        /// Adds item to the cart and redirect to "returnUrl"
        /// </summary>
        /// <param name="productId">Id of the product</param>
        /// <param name="quantity">quantity of the product</param>
        /// <param name="returnUrl">url to back</param>
        /// <returns></returns>
        public RedirectToRouteResult AddToCart(int? id, int quantity, string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.Id == id);

            if (product != null)
                GetCart().AddItem(product, quantity);

            return RedirectToAction("Index", new { returnUrl });
        }

        /// <summary>
        /// Removes the product from the cart
        /// </summary>
        /// <param name="productId">id of the product to remove</param>
        /// <param name="returnUrl">url to back</param>
        /// <returns></returns>
        public ActionResult RemoveFromCart(int? id, string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.Id == id);

            if (product != null)
            {
                Cart cart = GetCart();
                cart.RemoveLine(product);
                if (cart.Lines?.Count() == 0)
                    return Redirect("Index");
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public ViewResult Index (string returnUrl)
        {
            var cart = GetCart();
            return View(new CartIndexViewModel()
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }

        /// <summary>
        /// paying view
        /// </summary>
        /// <returns></returns>
        public ViewResult OrderView()
        {
            return View(GetCart());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public ViewResult SubmitOrder(string firstName, string lastName, string email, string phoneNumber, string returnUrl)
        {
            Cart cart = GetCart();

            if(cart != null)
            {
                List<Purchase> purchases = new List<Purchase>();
                
                foreach(var p in cart.Lines)
                {
                    purchases.Add(
                        new Purchase
                        {
                            CustomerEmail = email,
                            CustomerFirstName = firstName,
                            CustomerLastName = lastName,
                            CustomerPhone = phoneNumber,
                            ProductId = p.Product.Id,
                            PurchaseProductCount = p.Quantity,
                            PurchaseDate = DateTime.Now,
                            PurchaseGroupId = 100
                        });
                }
                repository.RegisterOrder(purchases);
            }
            Session["Cart"] = null;

            return View("OrderSuccess", cart);
        }

        public PartialViewResult Summary()
        {
            return PartialView("CartSummary", GetCart());
        }

        /// <summary>
        /// Returns session cart
        /// </summary>
        /// <returns></returns>
        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if(cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }        
    }
}