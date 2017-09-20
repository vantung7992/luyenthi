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
            CreateDethiSample(context);



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
            if (context.Topic.Count() == 0)
            {
                List<Topic> listChude = new List<Topic>()
            {
                new Topic {Name="Toán lớp 1"},
                new Topic {Name="Toán lớp 2" },
                new Topic {Name="Toán lớp 3" }
            };
                context.Topic.AddRange(listChude);
                context.SaveChanges();
            }
        }

        private void CreateCauhoiSample(LuyenthiDBContext context)
        {
            if (context.Question.Count() == 0)
            {
                List<Question> listQuestion = new List<Question>()
                {
                    new Question {TopicID=1, Content="Nội dung 1",DisplayContent="123", CreatedDate=DateTime.Now,Status=true},
                    new Question {TopicID=1,Content="Nội dung 2",DisplayContent="123",CreatedDate=DateTime.Now,Status=true},
                    new Question {TopicID=1,Content="Nội dung 3",DisplayContent="123",CreatedDate=DateTime.Now,Status=true},
                };
                List<Answer> listDapan = new List<Answer>()
                {
                    new Answer {QuestionID = 1,Content = "Nội dung 1",TrueAnswer=true,Code="A",CreatedDate=DateTime.Now },
                    new Answer {QuestionID = 1,Content = "Nội dung 2",TrueAnswer=false,Code="B",CreatedDate=DateTime.Now },
                    new Answer {QuestionID = 1,Content = "Nội dung 3",TrueAnswer=false,Code="C",CreatedDate=DateTime.Now },
                    new Answer {QuestionID = 1,Content = "Nội dung 4",TrueAnswer=false,Code="D",CreatedDate=DateTime.Now },
                    new Answer {QuestionID = 2,Content = "Nội dung 1",TrueAnswer=true,Code="A",CreatedDate=DateTime.Now },
                    new Answer {QuestionID = 2,Content = "Nội dung 2",TrueAnswer=false,Code="B",CreatedDate=DateTime.Now },
                    new Answer {QuestionID = 2,Content = "Nội dung 3",TrueAnswer=false,Code="C",CreatedDate=DateTime.Now },
                    new Answer {QuestionID = 2,Content = "Nội dung 4",TrueAnswer=false,Code="D",CreatedDate=DateTime.Now },
                    new Answer {QuestionID = 3,Content = "Nội dung 1",TrueAnswer=true,Code="A",CreatedDate=DateTime.Now },
                    new Answer {QuestionID = 3,Content = "Nội dung 2",TrueAnswer=false,Code="B",CreatedDate=DateTime.Now },
                    new Answer {QuestionID = 3,Content = "Nội dung 3",TrueAnswer=false,Code="C",CreatedDate=DateTime.Now },
                    new Answer {QuestionID = 3,Content = "Nội dung 4",TrueAnswer=false,Code="D",CreatedDate=DateTime.Now },
                };

                context.Question.AddRange(listQuestion);
                context.SaveChanges();
            }
        }

        private void CreateDethiSample(LuyenthiDBContext context)
        {
            if (context.Exam.Count() == 0)
            {
                List<Exam> listDethi = new List<Exam>() {
                    new Exam {Name="De thi 1",CreatedDate=DateTime.Now,Status=true},
                    new Exam {Name="De thi 2",CreatedDate=DateTime.Now,Status=true},
                    new Exam {Name="De thi 3",CreatedDate=DateTime.Now,Status=true}
                };
                context.Exam.AddRange(listDethi);
                context.SaveChanges();
            }
        }
    }
}
