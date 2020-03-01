using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Data.Infrastructure;
using Newtonsoft.Json;

namespace TestProject.Data.Models
{
    public class CartSession : Cart
    {
        public static Cart GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            CartSession cart = session?.GetJson<CartSession>("CartId") ?? new CartSession();
            cart.Session = session;
            return cart;
        }
        [JsonIgnore]
        public ISession Session { get; set; }
        public override void AddItem(Car car, int quartity)
        {
            base.AddItem(car, quartity);
            Session.SetJson("CartId", this);
        }
    }
}
