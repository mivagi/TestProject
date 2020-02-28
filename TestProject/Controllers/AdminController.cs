using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestProject.Data;
using TestProject.Data.Interfaces;
using TestProject.Data.Models;

namespace TestProject.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        private readonly AppDbContent content;
        private readonly IAllCars allCars;

        public AdminController(AppDbContent content, IAllCars allCars)
        {
            this.content = content;
            this.allCars = allCars;
        }
        public IActionResult Index()
        {
            return View(content.Cars);
        }
        public IActionResult Edite(int id)
        {
            return View(content.Cars.FirstOrDefault(p => p.Id == id));
        }
        [HttpPost]
        public IActionResult Edite(Car car)
        {
            if (ModelState.IsValid)
            {
                allCars.Create(car);
                return RedirectToAction("Index");
            }
            else
                return View(car);
        }
        public IActionResult Create()
        {
            return RedirectToAction("Edite", new Car());
        }
        public IActionResult Delete(int id)
        {
            allCars.Delete(id);
            return RedirectToAction("Index");
        }
    }
}