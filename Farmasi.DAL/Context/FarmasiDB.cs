using Farmasi.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Farmasi.DAL.Context
{
    public class FarmasiDB : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"server = (localdb)\MSSQLLocalDB; database=FarmasiDb; integrated security=true;");
            optionsBuilder.UseSqlServer(@"server =45.143.97.3; database =FarmasiDb; user id=kurumsal2; password=1FiveAjans; MultipleActiveResultSets=True;");
        }

        public DbSet<KategoriOne> KategoriOnes { get; set; }
        public DbSet<KategoriTwo> KategoriTwos { get; set; }
        public DbSet<Kullanici> Kullanici { get; set; }
        public DbSet<Musteri> Musteris { get; set; }
        public DbSet<MusteriSiparis> MusteriSiparis { get; set; }
        public DbSet<Sepet> Sepets { get; set; }
        public DbSet<Siparis> Siparis { get; set; }
        public DbSet<Urun> Uruns { get; set; }
        public DbSet<UrunSepet> UrunSepets { get; set; }
        public DbSet<SiparisUrun> SiparisUruns { get; set; }
        public DbSet<İletisim> İletisims { get; set; }

        public DbSet<Hakkimizda> Hakkimizdas { get; set; }

        public DbSet<Slider> Sliders { get; set; }

        public DbSet<Seo> Seos { get; set; }




    }
}
