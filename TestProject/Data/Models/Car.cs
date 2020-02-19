﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.Data.Models
{
    public class Car
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }
        //[Required]
        public string Img { get; set; }
        [Required]
        public int Price { get; set; }
    }
}
