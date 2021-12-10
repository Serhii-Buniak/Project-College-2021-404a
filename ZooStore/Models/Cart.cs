using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooStore.Models
{
    public class Cart
    {
        [Key, ForeignKey("AppUser")]
        public int Id { get; set; }
        public ICollection<Product> Products { get; set; }
    }

}
