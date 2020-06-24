using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Data.Models;

namespace TestProject.Data.Interfaces
{
    public interface IOrders
    {
        IEnumerable<Order> GetAllOrders { get; }
        void SaveOrder(Order order);
    }
}
