using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DersTakip.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int Id { get; set; }
        [Required]
        public long OgrenciNo { get; set; }
        public string? Adres {  get; set; }

    }
}
