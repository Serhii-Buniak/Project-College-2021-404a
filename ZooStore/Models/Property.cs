using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooStore.Models
{
    public class Property
    {
        [ScaffoldColumn(false), Key]
        public Guid Id { get; init; }
        [Required]
        public string Key { get; set; }
        [Required]
        public string Value { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

    }
}
