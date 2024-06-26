using DersTakip.Utility;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DersTakip.Models
{

	public class ProgramHftlkRepository : Repository<ProgramHftlk>, IProgramHftlkRepository
    {
		private readonly UygulamaDbContext _uygulamaDbContext;

		public ProgramHftlkRepository(UygulamaDbContext uygulamaDbContext) : base(uygulamaDbContext)
        {
			_uygulamaDbContext = uygulamaDbContext;
		}


        public IEnumerable<ProgramHftlk> GetAll()
        {
            return _uygulamaDbContext.ProgramHftkTbl.Include(p => p.Ogretmenler).ToList();
        }



        //public void Guncelle(Ogrenciler ogrenciler)
        //{
        //	_uygulamaDbContext.Update(ogrenciler);
        //}

        //public void Kaydet()
        //{
        //	_uygulamaDbContext.SaveChanges();
        //}
    }
}

