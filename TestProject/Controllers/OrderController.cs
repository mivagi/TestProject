using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestProject.Data;
using TestProject.Data.Interfaces;
using TestProject.Data.Models;

namespace TestProject.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders allOrders;
        private readonly Cart cart;
        private readonly AppDbContent content;

        public OrderController(IAllOrders allOrders, Cart cart, AppDbContent content)
        {
            this.allOrders = allOrders;
            this.cart = cart;
            this.content = content;
        }
        public IActionResult OrderIndex()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult CreateOrder(Order order)
        {
            var item = cart.GetCarts();
            if(item.Count == 0)
            {
                ModelState.AddModelError("", "Form necessarily complete");
            }
            if (ModelState.IsValid)
            {
                allOrders.CreateOrder(order);
                return RedirectToAction("Complete");
            }

            return View("OrderIndex", order);
        }
        public IActionResult Complete()
        {
            ViewBag.Message = "Order completed";
            return View();
        }
        public IActionResult OrderShow()
        {
            return View(allOrders.Orders);
        }
    }
}