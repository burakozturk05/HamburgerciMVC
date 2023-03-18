using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCPROJE.Areas.Identity.Data;
using MVCPROJE.Data;

namespace MVCPROJE.Context
{
    public class UygulamaDbContext : IdentityDbContext<Kullanici>
    {
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options) : base(options)
        {
        }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<ExtraMalzeme> ExtraMalzemes { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
   
