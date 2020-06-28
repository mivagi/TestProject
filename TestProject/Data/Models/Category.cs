using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.Data.Models
{
    //Категории товара
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Car> Cars { get; set; }
        public Category()
        {
            Cars = new List<Car>();
        }
    }
}
