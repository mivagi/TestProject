using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.Data.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter your FirstName")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Enter your LastName")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Enter your Email")]
        public string Email { get; set; }
        [BindNever]
        public List<OrderItem> OrderItems { get; set; }
        public Order()
        {
            OrderItems = new List<OrderItem>();
        }
    }
}
