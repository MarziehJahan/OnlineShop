using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;
using TK.Core.Contracts.Service;
using TK.Core.Entites;
using TK.Infrastruture.Sql;

namespace PresentationHost.Controllers
{
    [Authorize(Roles = "Admin")]
    [Authorize(Roles = "User")]
    public class CheckoutController : Controller
    {
        private readonly Cart cart;
        private readonly IOrderService orderService;
        private readonly UserManager<AppUser> userManager;

        public CheckoutController(Cart cart, IOrderService orderService,UserManager<AppUser> userManager)
        {
            this.cart = cart;
            this.orderService = orderService;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            ViewBag.cart = cart;
            return View(new Order());
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Index(Order order)
        {
            var totalPice = cart.GetTotalPrice();
            if (cart.CartLines.Count() == 0)
            {
                ModelState.AddModelError("", "سفارشی موجود نیست");
            }

            if (ModelState.IsValid)
            {
                order.Lines = cart.CartLines.ToList();
                AppUser appUser = new AppUser()
                {
                    UserName = order.Name,
                    PhoneNumber = order.Phone
                };
                IdentityResult result = userManager.CreateAsync(appUser, order.Password).Result;
                if (result.Succeeded)
                {
                    order.UserId = new Guid(appUser.Id);
                    orderService.SaveOrder(order);
                    cart.Clear();
                    return RedirectToAction("Pay",
                        "Payment", new { orderId = order.OrderID, totalPrice = totalPice });
                }
            }
            return View(order);
        }
    }
}
