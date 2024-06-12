namespace DersTakip.Models
{
    public interface IIsteklerRepository : IRepository<Istekler>
    {
        void Guncelle(Istekler istekler);
        void Kaydet();
    }
}
