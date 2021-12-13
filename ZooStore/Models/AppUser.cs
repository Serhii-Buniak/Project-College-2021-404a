using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooStore.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }

        [Required]
        [ForeignKey("CartId")]
        public virtual Cart Cart { get; set; }

        public virtual ICollection<ProductHistory> VisitedProducts { get; set; }
        public virtual ICollection<SearchHistory> SearchHistory { get; set; }
    }
}
