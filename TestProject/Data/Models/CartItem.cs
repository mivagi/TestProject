using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.Data.Models
{
    //Свойства в которых будет храниться товар пока он находится в корзине
    public class CartItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Car Car { get; set; }
        public int Quantity { get; set; }
    }
}
