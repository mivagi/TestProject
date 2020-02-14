using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Data.Interfaces;
using TestProject.Data.Models;

namespace TestProject.Data.Repository
{
    public class CarRepository : IAllCars
    {
        private readonly AppDbContent content;

        public CarRepository(AppDbContent content)
        {
            this.content = content;
        }
        public IEnumerable<Car> Cars => content.Cars;
    }
}
