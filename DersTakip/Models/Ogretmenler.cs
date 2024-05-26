using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DersTakip.Models
{
    public class Ogretmenler
    {
        [Key]   // primary key
        public int Id { get; set; }
        [Required]// not null
        [MaxLength(25)]
        [DisplayName("Öğretmenin Adı:")]
        public string Ad { get; set; }
        [Required]
        public string Soyad { get; set; }
        [Required]
        public string Brans {  get; set; }
        
        public string ResimUrl { get; set; }

    }
}
