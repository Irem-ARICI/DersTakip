using System.ComponentModel.DataAnnotations;

namespace DersTakip.Models
{
    public class Istekler
    {
        [Key]
        public int Id { get; set; }
        //
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Sinif { get; set; }
        public string Brans {  get; set; }
        public bool Sonuc {  get; set; }

    }
}
