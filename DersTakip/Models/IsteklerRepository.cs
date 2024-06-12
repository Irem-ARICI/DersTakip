using DersTakip.Utility;

namespace DersTakip.Models
{
    public class IsteklerRepository : Repository<Istekler>, IIsteklerRepository
    {
        private readonly UygulamaDbContext _uygulamaDbContext;
        public IsteklerRepository(UygulamaDbContext uygulamaDbContext) : base(uygulamaDbContext)
        {
            _uygulamaDbContext = uygulamaDbContext;
        }

        public void Guncelle(Istekler istekler)
        {
            _uygulamaDbContext.Update(istekler);
        }

        public void Kaydet()
        {
            _uygulamaDbContext.SaveChanges();
        }
    }
}
