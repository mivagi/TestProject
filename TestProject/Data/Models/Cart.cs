using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TestProject.Data.Models
{
    public class Cart
    {
        private readonly AppDbContent content;

        public Cart(AppDbContent content)
        {
            this.content = content;
        }
        public List<CartItem> ListItems { get; set; }
        public string CartName { get; set; }
        public static Cart GetCartName(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            AppDbContent content = service.GetRequiredService<AppDbContent>();
            string cartName = session.GetString("cartId") ?? Guid.NewGuid().ToString();
            session.SetString("cartId", cartName);

            return new Cart(content) { CartName = cartName };
        }
        public void AddToCart(Car car)
        {
            content.CartItems.Add(
                new CartItem { Car = car, CarId = car.Id, CartName = CartName }
                );
            content.SaveChanges();
        }
        public List<CartItem> GetCarts()
        {
            return content.CartItems.Where(p => p.CartName == CartName).Include(p => p.Car).ToList();
        }
    }
}
