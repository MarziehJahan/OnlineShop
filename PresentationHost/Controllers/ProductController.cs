using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PresentationHost.Models;
using TK.Core.Contracts.Service;
using TK.Core.Entites;

namespace PresentationHost.Controllers
{
    [AllowAnonymous]
    public class ProductController : Controller
    {
        private readonly IProdctService productService;

        public ProductController(IProdctService productService)
        {
            this.productService = productService;
        }
        public IActionResult Search(int page = 1, string category = "All", string q = "")
        {
            var data = productService.ProductSearch(q, category, page, 4);
            PagedList<Product> pageList = new PagedList<Product>(data.Item1, page, 4, data.Item2);
            ViewBag.category = category;
            ViewBag.q = q;

            return View(pageList);
        }

        public IActionResult SearchCategory(string category)
        {
            var data = productService.GetCategoryProducts(category);
            PagedList<Product> pageList = new PagedList<Product>(data.Item1, 1, 4, data.Item2);

            return View(pageList);
        }

        public IActionResult Detail(int id)
        {

            Product product = productService.Get(id);
            return View(product);
        }
    }
}
