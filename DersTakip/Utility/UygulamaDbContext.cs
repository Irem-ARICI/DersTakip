using DersTakip.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

// Veri Tabanında EF tablo oluşturması için ilgili Model Classlarını buraya eklemeliyiz <3 

namespace DersTakip.Utility
{
    public class UygulamaDbContext : IdentityDbContext
    {
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options) : base(options) {}

        public DbSet<Ogretmenler> OgretmenlerTbl { get; set; }
        public DbSet<Ogrenciler> OgrencilerTbl { get; set; }
        public DbSet<Istekler> IsteklerTbl { get;set; }
        public DbSet<ProgramHftlk> ProgramHftkTbl { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
