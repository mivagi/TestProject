using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestProject.Data.Interfaces;
using TestProject.Data.Models;

namespace TestProject.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrders orderRep;
        private readonly Cart cart;

        public OrderController(IOrders orderRep, Cart cart)
        {
            this.orderRep = orderRep;
            this.cart = cart;
        }
        [Authorize]
        public IActionResult List()
        {
            return View(orderRep.GetAllOrders);
        }
        public IActionResult Checkout()
        {
            return View(new Order());
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (ModelState.IsValid)
            {
                orderRep.SaveOrder(order);
                return RedirectToAction("Complete");
            }
            return View(order);
        }
        public IActionResult Complete()
        {
            cart.ClearCart();
            return View();
        }
        [HttpPost]
        public IActionResult DeleteOrder(int id)
        {
            orderRep.DeleteOrder(id);
            return RedirectToAction("List");
        }
    }
}
