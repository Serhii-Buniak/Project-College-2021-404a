using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooStore.Models
{
    public class Subcategory
    {
        public Guid Id { get; init; }
        [Required]
        public string Name { get; set; }
        [Required, ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
}
