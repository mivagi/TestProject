using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace TestProject.Data.Models
{
    //Корзина сайта. Метод GetCart добовляет в сессию строку
    //Метод AddItem добавляет в строку выбранный товар
    public class Cart
    {
        private List<CartItem> cartCollection = new List<CartItem>();
        public static Cart GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            Cart cart = session?.GetJson<Cart>("CartId") ?? new Cart();
            cart.Session = session;
            return cart;
        }
        [JsonIgnore]
        public ISession Session { get; set; }
        public void AddItem(Car car, int quartity)
        {
            CartItem item = cartCollection.Where(p => p.Car.Id == car.Id).FirstOrDefault();
            if (item == null)
            {
                cartCollection.Add(
                    new CartItem { Car = car, Quantity = quartity }
                    );
            }
            else
            {
                item.Quantity += quartity;
            }
            Session.SetJson("CartId", this);
        }
        public virtual IEnumerable<CartItem> Lines => cartCollection;
    }
}
