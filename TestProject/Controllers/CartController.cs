using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestProject.Data.Infrastructure;
using TestProject.Data.Interfaces;
using TestProject.Data.Models;
using TestProject.Data.ViewModels;

namespace TestProject.Controllers
{
    public class CartController : Controller
    {
        private readonly IAllCars allCars;

        public CartController(IAllCars allCars)
        {
            this.allCars = allCars;
        }
        public IActionResult CartIndex()
        {
            var cart = GetCart();
            return View(cart);
        }
        public IActionResult AddItem(int id)
        {
            var car = allCars.Cars.FirstOrDefault(p => p.Id == id);
            if(car != null)
            {
                Cart cart = GetCart();
                cart.AddItem(car, 1);
                SaveCart(cart);
            }
            
            return RedirectToAction("CartIndex");
        }
        private Cart GetCart()
        {
            Cart cart = HttpContext.Session.GetJson<Cart>("cartId") ?? new Cart();
            return cart;
        }
        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetJson("cartId", cart);
        }
    }
}