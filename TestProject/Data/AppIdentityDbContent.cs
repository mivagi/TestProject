using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Data.Models;

namespace TestProject.Data
{
    public class AppIdentityDbContent : IdentityDbContext<User>
    {
        public AppIdentityDbContent(DbContextOptions<AppIdentityDbContent> options) : base(options)
        {
        }
    }
}
