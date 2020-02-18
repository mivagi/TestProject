using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Data.Interfaces;
using TestProject.Data.Models;

namespace TestProject.Data.Repository
{
    public class OrderRepository : IAllOrders
    {
        private readonly AppDbContent content;
        private readonly Cart cart;

        public OrderRepository(AppDbContent content, Cart cart)
        {
            this.content = content;
            this.cart = cart;
        }
        //public IEnumerable<Order> Orders => content.Orders.Include(p => p.OrderDetailes);

        public void CreateOrder(Order order)
        {
            content.Orders.Add(order);
            cart.ListItems = cart.GetCarts();
            var items = cart.ListItems;
                foreach(var el in items)
                {
                    content.OrderDetailes.Add(
                        new OrderDetaile
                        {
                            CarId = el.Car.Id
                        });
                }
            content.SaveChanges();
        }
    }
}
