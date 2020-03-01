using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestProject.Data.Infrastructure;
using TestProject.Data.Interfaces;
using TestProject.Data.Models;

namespace TestProject.Controllers
{
    public class CartController : Controller
    {
        private readonly IAllCars allCars;
        private readonly Cart cart;

        public CartController(IAllCars allCars, Cart cart)
        {
            this.allCars = allCars;
            this.cart = cart;
        }
        public IActionResult CartIndex()
        {
            return View(cart);
        }
        public IActionResult AddItem(int id)
        {
            var car = allCars.Cars.FirstOrDefault(p => p.Id == id);
            if(car != null)
            {
                cart.AddItem(car, 1);
            }
            
            return RedirectToAction("CartIndex");
        }
        //private Cart GetCart()
        //{
        //    Cart cart = HttpContext.Session.GetJson<Cart>("cartId") ?? new Cart();
        //    return cart;
        //}
        //private void SaveCart(Cart cart)
        //{
        //    HttpContext.Session.SetJson("cartId", cart);
        //}
    }
}