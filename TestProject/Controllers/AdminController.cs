using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestProject.Data.Interfaces;
using TestProject.Data.Models;

namespace TestProject.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IAllCars allCars;

        public AdminController(IAllCars allCars)
        {
            this.allCars = allCars;
        }
        public IActionResult Index()
        {
            return View(allCars.Category);
        }
        public IActionResult EditCar(int id)
        {
            return View(allCars.Cars.FirstOrDefault(p => p.Id == id));
        }
        [HttpPost]
        public IActionResult EditCar(Car car)
        {
            if (ModelState.IsValid)
            {
                allCars.CreateCar(car);
                return RedirectToAction("Index");
            }
            return View(car);
        }
        [HttpPost]
        public IActionResult DeleteCar(int id)
        {
            allCars.DeleteCar(id);
            return RedirectToAction("Index");
        }
        public IActionResult CreateCar()
        {
            return View("EditCar", new Car());
        }
    }
}
