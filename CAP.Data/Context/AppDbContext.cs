using System.Reflection;
using CAP.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace CAP.Data.Context
{
    public class AppDbContext : DbContext
    {
        protected AppDbContext()
        {}

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {}

        //Tabloların ismini burada belirleriz.
        public DbSet<USERS> USERs { get; set; }
        public DbSet<TAXPAYER> TAXPAYERS { get; set; }
        public DbSet<ADDRESS> ADDRESSES { get; set; }

        //USERSMap.cs projesinden bu adıma gelindi.
        //USERSMap.cs projesine override yapılır.


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Buraada DBye aktarılmadan önce kolon konfigürasyonları yapılır.
            // Oluşturulan tüm tablolar için aşağıdaki komut kullanılır.

            // Burada IEntityTypeConfiguration'dan kalıtım alan tüm mapping sınıflarının
            // tanımlanması gerekir.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Burada tablo kolonlarının özelliklerini değiştirebiliri.
            // Aşağıdaki kodda kolonun boyutu değiştirildi.
            //modelBuilder.Entity<USERS>().Property(x => x.u_department).HasMaxLength(150);
        }
    }
}

