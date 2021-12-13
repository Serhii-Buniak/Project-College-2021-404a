using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooStore.Models
{
    public class Order
    {
        public long Id { get; set; }
        public virtual AppUser User { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    
        [Required]
        public virtual Department Department { get; set; }
        [Required]
        public DateTime DateTime { get; set; } = DateTime.Now;
        [Required]
        public virtual IList<OrderDetails> OrderDetails { get; set; }

        [NotMapped]
        public decimal TotalPrice => OrderDetails.Sum(p => p.TotalPrice);

    }
}
