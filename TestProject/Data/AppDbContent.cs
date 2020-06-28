using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Data.Models;

namespace TestProject.Data
{
    //Класс для взаимодействия с EntityFrameworkCore
    public class AppDbContent : IdentityDbContext<IdentityUser>
    {
        public AppDbContent(DbContextOptions<AppDbContent> options) : base(options)
        {
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
