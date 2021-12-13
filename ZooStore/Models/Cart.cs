using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using ZooStore.Data;

namespace ZooStore.Models
{
    public class Cart
    {
        [Key]
        public long Id { get; set; }
        public virtual AppUser User { get; set; }
        public virtual ISet<CartDetails> CartDetails { get; set; }
    }

}
