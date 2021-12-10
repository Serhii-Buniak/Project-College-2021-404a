using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooStore.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }

}
