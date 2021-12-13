using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZooStore.Models
{
    public class Category
    {
        public long Id { get; init; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Subcategory> Subcategories { get; set; }
    }
}
