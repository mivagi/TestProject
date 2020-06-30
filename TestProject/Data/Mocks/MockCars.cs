using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Data.Interfaces;
using TestProject.Data.Models;

namespace TestProject.Data.Mocks
{
    public class MockCars //: IAllCars
    {
        public IEnumerable<Car> Cars
        {
            get
            {
                return new List<Car>
                {
                    new Car{Name = "Tesla", Price = 2000000, Img1 = "/img/tesla.jpg"},
                    new Car{Name = "Mercedes", Price = 2200000, Img1 = "/img/mercedes.jpg"}
                };
            }
        }
    }
}
