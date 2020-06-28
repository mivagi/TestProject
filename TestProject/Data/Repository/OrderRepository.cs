using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Data.Interfaces;
using TestProject.Data.Models;

namespace TestProject.Data.Repository
{
    //Класс для работы с таблицей Orders в базе данных
    public class OrderRepository : IOrders
    {
        private readonly AppDbContent content;
        private readonly Cart cart;

        public OrderRepository(AppDbContent content, Cart cart)
        {
            this.content = content;
            this.cart = cart;
        }
        public IEnumerable<Order> GetAllOrders => content.Orders.Include(p => p.OrderItems).ThenInclude(l => l.Car);
        public void SaveOrder(Order order)
        {
            content.Orders.Add(order);
            content.SaveChanges();
            var items = cart.Lines;
            foreach(var el in items)
            {
                content.OrderItems.Add(
                    new OrderItem
                    {
                        Name = el.Car.Name,
                        Quantity = el.Quantity,
                        OrderId = order.Id,
                        Price = el.Car.Price
                    });
            }
            content.SaveChanges(); 
        }
        public void DeleteOrder(int id)
        {
            var order = content.Orders.Include(o => o.OrderItems).FirstOrDefault(p => p.Id == id);
            if (order != null)
            {
                content.Orders.Remove(order);
                content.SaveChanges();
            }
        }
    }
}
