﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZooStore.Models.ViewModels
{
    public class ProductForm
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Guid SubcategoryId { get; set; }
        [Required]
        public IList<Property> Properties { get; set; }


        [Required(ErrorMessage = "Please choose profile image")]
        [Display(Name = "Product Picture")]
        public IFormFile Image { get; set; }

        
    }
}
