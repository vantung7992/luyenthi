namespace LuyenThi.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LuyenThi.Data.LuyenthiDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LuyenThi.Data.LuyenthiDBContext context)
        {
            CreateChudeSample(context);
            CreateCauhoiSample(context);



            //  This method will be called after migrating to the latest version.
            //var manager = new UserManager<ApplicationUser>(new Microsoft.AspNet.Identity.EntityFramework.UserStore<ApplicationUser>(new LuyenthiDBContext()));
            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new LuyenthiDBContext()));

            //var user = new ApplicationUser()
            //{
            //    UserName = "VanTung",
            //    Email = "tungnv@abic.com.vn",
            //    Ngaysinh = DateTime.Now,
            //    Hoten = "Nguyen van tung"
            //};

            //manager.Create(user, "123456$");
            //if (!roleManager.Roles.Any())
            //{
            //    roleManager.Create(new IdentityRole { Name = "Admin" });
            //    roleManager.Create(new IdentityRole { Name = "User" });
            //}
            //var adminUser = manager.FindByEmail("tungnv@abic.com.vn");
            //manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
        }

        private void CreateChudeSample(LuyenThi.Data.LuyenthiDBContext context)
        {
            if (context.Chude.Count() == 0)
            {
                List<Chude> listChude = new List<Chude>()
            {
                new Chude {Ten="Toán lớp 1"},
                new Chude {Ten="Toán lớp 2" },
                new Chude {Ten="Toán lớp 3" }
            };
                context.Chude.AddRange(listChude);
                context.SaveChanges();
            }
        }

        private void CreateCauhoiSample(LuyenthiDBContext context)
        {
            if (context.Cauhoi.Count() == 0)
            {
                List<Cauhoi> listCauhoi = new List<Cauhoi>()
                {
                    new Cauhoi {Noidung="Nội dung 1",Ngaytao=DateTime.Now,Trangthai=true},
                    new Cauhoi {Noidung="Nội dung 2",Ngaytao=DateTime.Now,Trangthai=true},
                    new Cauhoi {Noidung="Nội dung 3",Ngaytao=DateTime.Now,Trangthai=true},
                };
                List<Dapan> listDapan = new List<Dapan>()
                {
                    new Dapan {IDCauhoi = 1,Noidung = "Nội dung 1",Dungsai=true,Ma="A",Ngaytao=DateTime.Now },
                    new Dapan {IDCauhoi = 1,Noidung = "Nội dung 2",Dungsai=false,Ma="B",Ngaytao=DateTime.Now },
                    new Dapan {IDCauhoi = 1,Noidung = "Nội dung 3",Dungsai=false,Ma="C",Ngaytao=DateTime.Now },
                    new Dapan {IDCauhoi = 1,Noidung = "Nội dung 4",Dungsai=false,Ma="D",Ngaytao=DateTime.Now },
                    new Dapan {IDCauhoi = 2,Noidung = "Nội dung 1",Dungsai=true,Ma="A",Ngaytao=DateTime.Now },
                    new Dapan {IDCauhoi = 2,Noidung = "Nội dung 2",Dungsai=false,Ma="B",Ngaytao=DateTime.Now },
                    new Dapan {IDCauhoi = 2,Noidung = "Nội dung 3",Dungsai=false,Ma="C",Ngaytao=DateTime.Now },
                    new Dapan {IDCauhoi = 2,Noidung = "Nội dung 4",Dungsai=false,Ma="D",Ngaytao=DateTime.Now },
                    new Dapan {IDCauhoi = 3,Noidung = "Nội dung 1",Dungsai=true,Ma="A",Ngaytao=DateTime.Now },
                    new Dapan {IDCauhoi = 3,Noidung = "Nội dung 2",Dungsai=false,Ma="B",Ngaytao=DateTime.Now },
                    new Dapan {IDCauhoi = 3,Noidung = "Nội dung 3",Dungsai=false,Ma="C",Ngaytao=DateTime.Now },
                    new Dapan {IDCauhoi = 3,Noidung = "Nội dung 4",Dungsai=false,Ma="D",Ngaytao=DateTime.Now },
                };

                context.Cauhoi.AddRange(listCauhoi);
                context.SaveChanges();
            }
        }
    }
}
