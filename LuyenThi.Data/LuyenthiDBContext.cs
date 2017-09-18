using LuyenThi.Model.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace LuyenThi.Data
{
    public class LuyenthiDBContext : IdentityDbContext<ApplicationUser>
    {
        public LuyenthiDBContext() : base("LuyenthiConnections")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Topic> Topic { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Answer> Answer { get; set; }
        public DbSet<Exam> Exam { get; set; }
        public DbSet<ExamDetail> ExamDetail { get; set; }
        public DbSet<ExamTopic> ExamTopic { get; set; }
        public DbSet<Error> Error { get; set; }

        public static LuyenthiDBContext Create()
        {
            return new LuyenthiDBContext();
        }

        protected override void OnModelCreating(DbModelBuilder buider)
        {
            buider.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId });
            buider.Entity<IdentityUserLogin>().HasKey(i => i.UserId);
        }
    }
}