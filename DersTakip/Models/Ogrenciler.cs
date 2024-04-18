using System.ComponentModel.DataAnnotations;

namespace DersTakip.Models
{
    public class Ogrenciler
    {
        [Key]
        [MaxLength(11)]
        public string TC { get; set; }
        [Required]
        [MaxLength(25)]
        public string AdSoyad { get; set; }
        [Required(ErrorMessage = "Telefon numarını yazmayı unutmayınız!")]
        public string TelNo { get; set; }
        [Required]
        public string Mail { get; set; }
        [Required]
        public string Sinifi {  get; set; }

    }
}
