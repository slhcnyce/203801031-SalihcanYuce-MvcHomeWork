using Microsoft.EntityFrameworkCore;
using Sube1.HelloMVC.Models;

namespace Sube1.HelloMVC
{
    public class OkulDbContext : DbContext
    {
        public OkulDbContext(DbContextOptions<OkulDbContext> options) : base(options)
        {
        }

        public DbSet<Ogrenci> Ogrenciler { get; set; }

        public DbSet<Ders> Dersler { get; set; }

        public DbSet<OgrenciDers> OgrenciDersler { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-BM64HT3\\SQLEXPRESS;Initial Catalog=OkulDbSube2MVC;Integrated Security=true;TrustServerCertificate=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ogrenci>().ToTable("tblOgrenciler");
            modelBuilder.Entity<Ogrenci>().Property(o => o.Ad).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Ogrenci>().Property(o => o.Soyad).HasColumnType("varchar").HasMaxLength(40).IsRequired();
            modelBuilder.Entity<Ogrenci>().Property(o => o.Numara).IsRequired();

            modelBuilder.Entity<Ders>().ToTable("tblDersler");
            modelBuilder.Entity<Ders>().Property(o => o.Dersad).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Ders>().Property(o => o.Kredi).HasColumnType("tinyint").IsRequired();

            modelBuilder.Entity<OgrenciDers>()
               .HasKey(od => new { od.Ogrenciid, od.Dersid });

            modelBuilder.Entity<OgrenciDers>()
                .HasOne(od => od.Ogrenci)
                .WithMany(o => o.OgrenciDersler)
                .HasForeignKey(od => od.Ogrenciid);

            modelBuilder.Entity<OgrenciDers>()
                .HasOne(od => od.Ders)
                .WithMany(d => d.OgrenciDersler)
                .HasForeignKey(od => od.Dersid);
        }

    }
}
