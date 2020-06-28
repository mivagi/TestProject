using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.Data.Models
{
    //Сюда записываются товары которые выбрал заказчик
    public class OrderItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public Car Car { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
