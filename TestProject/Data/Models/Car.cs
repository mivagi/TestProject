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
        public int Price { get; set; }
        public int MaxSpeed { get; set; }
        public double Racing { get; set; }
        public string Drive { get; set; }
        public string Body { get; set; }
        public string Img1 { get; set; }
        public string Img2 { get; set; }
        public string Img3 { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
