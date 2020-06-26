using Microsoft.EntityFrameworkCore;
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
        public IEnumerable<Car> Category => content.Cars.Include(p => p.Category);
        public void CreateCar(Car car)
        {
            if (car.Id == 0)
            {
                content.Cars.Add(car);
            }
            else
            {
                Car newCar = content.Cars.FirstOrDefault(p => p.Id == car.Id);
                newCar.Name = car.Name;
                newCar.Img = car.Img;
                newCar.Price = car.Price;
                newCar.CategoryId = car.CategoryId;
                newCar.Category = car.Category;
            }
            content.SaveChanges();
        }

        public void DeleteCar(int id)
        {
            Car car = content.Cars.FirstOrDefault(p => p.Id == id);
            if (car != null)
            {
                content.Cars.Remove(car);
                content.SaveChanges();
            }
        }
    }
}
