using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooStore.Models
{
    public abstract class Product
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public ProductImage Image { get; set; }

        [Required]
        public Category Category { get; set; }
    }
}
