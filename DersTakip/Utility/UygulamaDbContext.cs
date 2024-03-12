using DersTakip.Models;
using Microsoft.EntityFrameworkCore;

namespace DersTakip.Utility
{
    public class UygulamaDbContext : DbContext
    {
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options) : base(options) {}

        public DbSet<Ogretmenler> OgretmenlerTbl { get; set; }
    }
}
