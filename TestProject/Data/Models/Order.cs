using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace TestProject.Data.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter your adress")]
        public string Adress { get; set; }
        public List<OrderDetaile> OrderDetailes { get; set; }
    }
}
