using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Data.Models;

namespace TestProject.Data.Interfaces
{
    public interface IAllOrders
    {
        IEnumerable<Order> Orders { get; }
        void CreateOrder(Order order);
        List<Order> GetOrder();
        List<Order> ListOrder { get; set; }
    }
}
