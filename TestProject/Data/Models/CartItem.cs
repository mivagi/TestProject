using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.Data.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public Car Car { get; set; }
        public int Quantity { get; set; }
    }
}
