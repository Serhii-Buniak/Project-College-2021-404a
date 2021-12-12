using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooStore.Models
{
    public class OrderDetails
    {
        public long Id { get; set; }

        public long OrderId { get; set; }
        [Required]
        [Range(1, 1_000_000)]
        public int Quantity { get; set; }
        [Required]
        public long ProductId { get; set; }   
        public virtual Product Product { get; set; }

        [NotMapped]
        public decimal TotalPrice => (Product?.Price ?? 0) * Quantity;

    }
}
