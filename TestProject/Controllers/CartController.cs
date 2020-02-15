using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Data.Interfaces;
using TestProject.Data.Models;

namespace TestProject.Controllers
{
    public class CartController : Controller
    {
        private readonly Cart cart;
        private readonly IAllCars allCars;

        public CartController(Cart cart, IAllCars allCars)
        {
            this.cart = cart;
            this.allCars = allCars;
        }
        public IActionResult CartIndex()
        {
            cart.ListItems = cart.GetCarts();
            //var items = cart.ListItems;
            return View(cart);
        }
        public IActionResult AddToCart(int id)
        {
            var item = allCars.Cars.FirstOrDefault(p => p.Id == id);
            if(item != null)
            {
                cart.AddToCart(item);
            }
            return RedirectToAction("CartIndex");
        }
    }
}
