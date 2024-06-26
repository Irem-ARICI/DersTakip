using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace DersTakip.Models
{
    public class ProgramHftlk
    {
        public int Id { get; set; }
        public bool İste { get; set; }

        public DateTime Tarih { get; set; }

		[ValidateNever]
		public int OgretmenlerId { get; set; }

		[ValidateNever]
		public Ogretmenler Ogretmenler { get; set; }
	}
}
