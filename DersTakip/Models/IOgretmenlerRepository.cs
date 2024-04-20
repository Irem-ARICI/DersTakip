namespace DersTakip.Models
{
    public interface IOgretmenlerRepository : IRepository<Ogretmenler>
    {
        void Guncelle(Ogretmenler ogretmenler);
        void Kaydet();
    }
}
