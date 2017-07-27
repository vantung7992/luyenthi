using LuyenThi.Model.Models;
using System.Data.Entity;

namespace LuyenThi.Data
{
    public class LuyenthiDBContext : DbContext
    {
        public LuyenthiDBContext() : base("LuyenthiConnections")
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
        public DbSet<Error> Error { get; set; }

        public static LuyenthiDBContext Create()
        {
            return new LuyenthiDBContext();
        }

        protected override void OnModelCreating(DbModelBuilder buider)
        {
        }
    }
}