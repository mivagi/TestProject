using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.Data.Models
{
    //Товар который продается на сайте
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public int Price { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
