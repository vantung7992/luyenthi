using LuyenThi.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuyenThi.Data
{
    public class LuyenthiDBContext : DbContext
    {
        public LuyenthiDBContext() : base("LuyenthiConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Chude> Chude { get; set; }
        public DbSet<Cauhoi> Cauhoi { get; set; }
        public DbSet<Dapan> Dapan { get; set; }
        public DbSet<Dethi> Dethi { get; set; }
        public DbSet<DethiCauhoi> DethiCauhoi { get; set; }
        public DbSet<ChudeCauhoi> ChudeCauhoi { get; set; }
        public DbSet<ChudeDethi> ChudeDethi { get; set; }

        protected override void OnModelCreating(DbModelBuilder buider)
        {
        }
    }
}
