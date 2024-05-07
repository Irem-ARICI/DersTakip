using DersTakip.Utility;

namespace DersTakip.Models
{
    public class OgrencilerRepository : Repository<Ogrenciler>, IOgrencilerRepository
    {
        private readonly UygulamaDbContext _uygulamaDbContext;
        public OgrencilerRepository(UygulamaDbContext uygulamaDbContext) : base(uygulamaDbContext)
        {
            _uygulamaDbContext = uygulamaDbContext;
        }

        public void Guncelle(Ogrenciler ogrenciler)
        {
            _uygulamaDbContext.Update(ogrenciler);
        }

        public void Kaydet()
        {
            _uygulamaDbContext.SaveChanges();
        }
    }
}
