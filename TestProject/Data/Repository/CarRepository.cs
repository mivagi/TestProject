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

        public void Create(Car car)
        {
            if(car.Id == 0)
            {
                content.Cars.Add(car);
            }
            else
            {
                Car createCar = content.Cars.FirstOrDefault(p => p.Id == car.Id);
                if (createCar != null)
                {
                    createCar.Img = car.Img;
                    createCar.Name = car.Name;
                    createCar.Price = car.Price;
                }
            }
            
            content.SaveChanges();
        }

        public void Delete(int id)
        {
            Car deleteCar = content.Cars.FirstOrDefault(p => p.Id == id);
            content.Cars.Remove(deleteCar);
            content.SaveChanges();
        }
    }
}
