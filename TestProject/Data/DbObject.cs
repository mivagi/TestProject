using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Data.Models;

namespace TestProject.Data
{
    public class DbObject
    {
        public static void Initial(AppDbContent content)
        {
            if (!content.Categories.Any())
            {
                content.Categories.Add(new Category { Name = "electro"});
                content.Categories.Add(new Category { Name = "fuil"});
            }
            content.SaveChanges();
            if (!content.Cars.Any())
            {
                content.Cars.AddRange(
                    new Car { Name = "Tesla", Price = 2100000, Img = "/img/tesla.jpg", CategoryId = 1 },
                    new Car { Name = "Nissan", Price = 2200000, Img = "/img/nissan.jpg", CategoryId = 1 },
                    new Car { Name = "Mercedes", Price = 2300000, Img = "/img/mercedes.jpg", CategoryId = 2 },
                    new Car { Name = "BMW", Price = 2000000, Img = "/img/bmw.jpg", CategoryId = 2 },
                    new Car { Name = "Fiesta", Price = 1900000, Img = "/img/fiesta.jpg", CategoryId = 2 }
                    );
            }
            content.SaveChanges();
        }
    }
}
