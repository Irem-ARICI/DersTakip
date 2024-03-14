using DersTakip.Models;
using Microsoft.EntityFrameworkCore;

namespace DersTakip.Utility
{
    public class UygulamaDbContext : DbContext
    {
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options) : base(options) {}

        public DbSet<Ogretmenler> OgretmenlerTbl { get; set; }
        public DbSet<Ogrenciler> OgrencilerTbl { get; set; }
        public DbSet<Istekler> IsteklerTbl { get;set; }
    }
}
