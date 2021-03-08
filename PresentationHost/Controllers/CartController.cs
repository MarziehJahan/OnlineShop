using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TK.Core.Contracts.Service;
using TK.Core.Entites;

namespace PresentationHost.Controllers
{
    public class CartController : Controller
    {
        private readonly IProdctService prodctService;
        private readonly Cart cart;

        public CartController(IProdctService prodctService, Cart cart)
        {
            this.prodctService = prodctService;
            this.cart = cart;
        }
        public IActionResult Index()
        {
            return View(cart);
        }

        public IActionResult AddToCart(int productId, int qunaity)
        {
            string referer = Request.Headers["Referer"].ToString();
            Product product = prodctService.Get(productId);
            if (product != null)
            {
                cart.AddItem(product, qunaity);
            }
            return Redirect(referer);
        }

        public IActionResult EditCart(List<int> productId, List<int> qunaity)
        {
            List<Product> product = new List<Product>();
            for (int i = 0; i < productId.Count; i++)
            {
                product.Add(prodctService.Get(productId[i]));
                cart.AddItem(product[i], qunaity[i]);
            }

            return RedirectToAction("Index");
        }
    }
}
