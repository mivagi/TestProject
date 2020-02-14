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
            if (!content.Cars.Any())
            {
                content.Cars.AddRange(
                    new Car { Name = "Tesla", Price = 2100000, Img = "/img/tesla.jpg" },
                    new Car { Name = "Mercedes", Price = 2300000, Img = "/img/mercedes.jpg" }
                    );
            }
            content.SaveChanges();
        }
    }
}
