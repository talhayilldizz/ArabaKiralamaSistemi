using ArabaTakipSistemi.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabaTakipSistemi.Contexts
{
    public class AracTakip:DbContext
    {
        public DbSet<Kullanici> kullanicilar { get; set; }

        public DbSet<Araba> arabalar { get; set; }

        public DbSet<İslem> islemler { get; set; }
    }
}
