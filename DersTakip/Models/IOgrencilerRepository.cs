namespace DersTakip.Models
{
    public interface IOgrencilerRepository : IRepository<Ogrenciler>
    {
        void Guncelle(Ogrenciler ogrenciler);
        void Kaydet();
    }
}
