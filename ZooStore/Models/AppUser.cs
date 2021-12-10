using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ZooStore.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        [PersonalData]
        public string FullName { get; set; }

        public Cart Cart { get; set; }
    }
}
