using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ZooStore.Models
{
    public class Product
    {
        [ScaffoldColumn(false), Key]
        public long Id { get; init; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; }

        [ForeignKey("SubcategoryId")]
        public virtual Subcategory Subcategory { get; set; }
        public virtual ICollection<Property> Properties { get; set; }

        [Required(ErrorMessage = "Please choose picture")]
        public string Picture { get; set; }

        [NotMapped]
        public string this[string key] => Properties.First(p => p.Key == key).Value;

        [NotMapped]
        public Category Category => Subcategory.Category;
        public bool Unique { get; set; }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Id.Equals(((Product)obj).Id);
        }

    }
}
