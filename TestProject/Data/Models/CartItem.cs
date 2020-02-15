using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.Data.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public string CartName { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
