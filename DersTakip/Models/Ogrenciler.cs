using System.ComponentModel.DataAnnotations;

namespace DersTakip.Models
{
    public class Ogrenciler
    {
        [Key]
        public string TC { get; set; }
        [Required]
        public string AdSoyad { get; set; }
        [Required]
        public string TelNo { get; set; }
        [Required]
        public string Mail { get; set; }
        [Required]
        public string Sinifi {  get; set; }

    }
}
