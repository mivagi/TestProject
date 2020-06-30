using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestProject.Data.Interfaces;

namespace TestProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllCars allCars;

        public HomeController(IAllCars allCars)
        {
            this.allCars = allCars;
        }
        public IActionResult Index()
        {
            return View(allCars.Cars);
        }
        public IActionResult OneCar(int id)
        {
            var car = allCars.GetOneCar(id);
            return View(car);
        }
    }
}