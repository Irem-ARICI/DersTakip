using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace DersTakip.Models
{
    public class Istekler
    {
        [Key]
        public int Id { get; set; }
        //
        public string AdSoyad { get; set; }
        public string Sinif { get; set; }
        public string Brans {  get; set; }
        public bool Sonuc {  get; set; }

        [Required]
        public int OgrenciId { get; set; }

        [ValidateNever]
        public int OgretmenlerId { get; set; }

        [ValidateNever]
        public Ogretmenler Ogretmenler { get; set;}


    }
}
