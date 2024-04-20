using DersTakip.Utility;

namespace DersTakip.Models
{
    public class OgretmenlerRepository : Repository<Ogretmenler>, IOgretmenlerRepository    // Clean code <3
    {
        private readonly UygulamaDbContext _uygulamaDbContext;
        public OgretmenlerRepository(UygulamaDbContext uygulamaDbContext) : base(uygulamaDbContext)
        {
            _uygulamaDbContext = uygulamaDbContext;
        }

        public void Guncelle(Ogretmenler ogretmenler)
        {
            _uygulamaDbContext.Update(ogretmenler);
        }

        public void Kaydet()
        {
            _uygulamaDbContext.SaveChanges();
        }
    }
}
