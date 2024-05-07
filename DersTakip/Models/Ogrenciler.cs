using System.ComponentModel.DataAnnotations;

namespace DersTakip.Models
{
    public class Ogrenciler
    {
        public int Id { get; set; }
        
        public long TC { get; set; }
        [Required]
        [MaxLength(25)]
        public string AdSoyad { get; set; }
        [Required(ErrorMessage = "Telefon numarını yazmayı unutmayınız!")]
        public string TelNo { get; set; }
        [Required]
        public string Mail { get; set; }
        [Required]
        public string Sinifi {  get; set; }
        //public int? Id { get; internal set; }
    }
}
