using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Data.Models;

namespace TestProject.Data
{
    //Класс заполняющий базу данных данными
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
                    new Car
                    {
                        Name = "Tesla Motors Roadster",
                        Price = 7700000,
                        Racing = 3.7f,
                        MaxSpeed = 201,
                        Body = "Кабриолет",
                        Drive = "Задний",
                        Img1 = "/img/tesla1.jpg",
                        Img2 = "/img/tesla2.jpg",
                        Img3 = "/img/tesla3.jpg",
                        CategoryId = 1
                    },
                    new Car
                    {
                        Name = "Nissan Liaf",
                        Price = 650000,
                        Racing = 7.9f,
                        MaxSpeed = 144,
                        Body = "Хэтчбек",
                        Drive = "Передний",
                        Img1 = "/img/nissan1.jpg",
                        Img2 = "/img/nissan2.jpg",
                        Img3 = "/img/nissan3.jpg",
                        CategoryId = 1
                    },
                    new Car
                    {
                        Name = "Mercedes Benz AMG GT 63",
                        Price = 9490000,
                        Racing = 3.4f,
                        MaxSpeed = 310,
                        Body = "Лифтбек",
                        Drive = "Полный",
                        Img1 = "/img/mercedes1.jpg",
                        Img2 = "/img/mercedes2.jpg",
                        Img3 = "/img/mercedes3.jpg",
                        CategoryId = 2
                    },
                    new Car
                    {
                        Name = "BMW 8 Series",
                        Price = 7610000,
                        Racing = 3.7f,
                        MaxSpeed = 250,
                        Body = "Купе",
                        Drive = "Полный",
                        Img1 = "/img/bmw1.jpg",
                        Img2 = "/img/bmw2.jpg",
                        Img3 = "/img/bmw3.jpg",
                        CategoryId = 2
                    },
                    new Car
                    {
                        Name = "Audi Q8",
                        Price = 5900000,
                        Racing = 5.9f,
                        MaxSpeed = 250,
                        Body = "Универсал",
                        Drive = "Полный",
                        Img1 = "/img/audi1.jpg",
                        Img2 = "/img/audi2.jpg",
                        Img3 = "/img/audi3.jpg",
                        CategoryId = 2
                    });
            }
            content.SaveChanges();
        }
        public static async Task InitialazeIdentity(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminName = "admin";
            string adminPassword = "!Q2w3e4r";

            if(await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if(await userManager.FindByNameAsync("admin") == null)
            {
                IdentityUser admin = new IdentityUser { UserName = adminName };
                var result = await userManager.CreateAsync(admin, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
        }
    }
}
