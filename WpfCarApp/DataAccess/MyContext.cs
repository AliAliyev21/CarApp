using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Sockets;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using WpfCarApp.Entities;

namespace WpfCarApp.DataAccess
{
    public class MyContext : DbContext
    {
        public MyContext()
            : base("CarDB") { }

        public DbSet<BanNovu> BanNovus { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<BuraxilisIli> BuraxilisIlis { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<NewOrOld> NewsOrOlds { get; set; }
        public DbSet<PetrolType> PetrolTypes { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Yurus> Yuruss { get; set; }
    }
}
