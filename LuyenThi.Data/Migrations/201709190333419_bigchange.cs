namespace LuyenThi.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bigchange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ChudeCauhoi", "IDCauhoi", "dbo.Cauhoi");
            DropForeignKey("dbo.ChudeCauhoi", "IDChude", "dbo.Chude");
            DropForeignKey("dbo.ChudeDethi", "IDChude", "dbo.Chude");
            DropForeignKey("dbo.ChudeDethi", "IDDethi", "dbo.Dethi");
            DropForeignKey("dbo.Dapan", "IDCauhoi", "dbo.Cauhoi");
            DropForeignKey("dbo.DethiCauhoi", "IDCauhoi", "dbo.Cauhoi");
            DropForeignKey("dbo.DethiCauhoi", "IDDethi", "dbo.Dethi");
            DropIndex("dbo.ChudeCauhoi", new[] { "IDChude" });
            DropIndex("dbo.ChudeCauhoi", new[] { "IDCauhoi" });
            DropIndex("dbo.ChudeDethi", new[] { "IDChude" });
            DropIndex("dbo.ChudeDethi", new[] { "IDDethi" });
            DropIndex("dbo.Dapan", new[] { "IDCauhoi" });
            DropIndex("dbo.DethiCauhoi", new[] { "IDDethi" });
            DropIndex("dbo.DethiCauhoi", new[] { "IDCauhoi" });
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        QuestionID = c.Int(nullable: false),
                        Content = c.String(nullable: false),
                        Code = c.String(nullable: false, maxLength: 3),
                        Order = c.Int(nullable: false),
                        TrueAnswer = c.Boolean(nullable: false),
                        Image = c.String(),
                        Status = c.Boolean(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        Note = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Questions", t => t.QuestionID, cascadeDelete: true)
                .Index(t => t.QuestionID);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TopicID = c.Int(nullable: false),
                        Content = c.String(nullable: false),
                        DisplayContent = c.String(nullable: false, storeType: "ntext"),
                        Suggest = c.String(maxLength: 1000),
                        Image = c.String(maxLength: 256),
                        Tag = c.String(maxLength: 200, unicode: false),
                        Status = c.Boolean(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        Note = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Topics", t => t.TopicID, cascadeDelete: true)
                .Index(t => t.TopicID);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        ParentID = c.Int(),
                        Seo = c.String(maxLength: 200),
                        Tag = c.String(maxLength: 200, unicode: false),
                        Description = c.String(maxLength: 500),
                        Image = c.String(maxLength: 256),
                        HomeFlag = c.Boolean(),
                        HotFlag = c.Boolean(),
                        ViewCount = c.Int(),
                        Status = c.Boolean(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        Note = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Seo = c.String(maxLength: 200),
                        Description = c.String(storeType: "ntext"),
                        Image = c.String(maxLength: 500),
                        TimeToDo = c.Int(),
                        Tag = c.String(maxLength: 200, unicode: false),
                        HomeFlag = c.Boolean(),
                        HotFlag = c.Boolean(),
                        ViewCount = c.Int(),
                        Status = c.Boolean(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        Note = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ExamDetail",
                c => new
                    {
                        ExamID = c.Int(nullable: false),
                        QuestionID = c.Int(nullable: false),
                        Order = c.Int(nullable: false),
                        Status = c.Boolean(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        Note = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => new { t.ExamID, t.QuestionID })
                .ForeignKey("dbo.Exams", t => t.ExamID, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.QuestionID, cascadeDelete: true)
                .Index(t => t.ExamID)
                .Index(t => t.QuestionID);
            
            CreateTable(
                "dbo.ExamTopics",
                c => new
                    {
                        TopicID = c.Int(nullable: false),
                        ExamID = c.Int(nullable: false),
                        Status = c.Boolean(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        Note = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => new { t.TopicID, t.ExamID })
                .ForeignKey("dbo.Exams", t => t.ExamID, cascadeDelete: true)
                .ForeignKey("dbo.Topics", t => t.TopicID, cascadeDelete: true)
                .Index(t => t.TopicID)
                .Index(t => t.ExamID);
            
            DropTable("dbo.Cauhoi");
            DropTable("dbo.Chude");
            DropTable("dbo.ChudeCauhoi");
            DropTable("dbo.ChudeDethi");
            DropTable("dbo.Dethi");
            DropTable("dbo.Dapan");
            DropTable("dbo.DethiCauhoi");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DethiCauhoi",
                c => new
                    {
                        IDDethi = c.Int(nullable: false),
                        IDCauhoi = c.Int(nullable: false),
                        Thutu = c.Int(nullable: false),
                        Trangthai = c.Boolean(nullable: false),
                        Ngaytao = c.DateTime(),
                        Nguoitao = c.String(maxLength: 256),
                        Ngaysua = c.DateTime(),
                        Nguoisua = c.String(maxLength: 256),
                        Ghichu = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => new { t.IDDethi, t.IDCauhoi });
            
            CreateTable(
                "dbo.Dapan",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Noidung = c.String(nullable: false),
                        Ma = c.String(nullable: false, maxLength: 3),
                        Thutu = c.Int(nullable: false),
                        Dungsai = c.Boolean(nullable: false),
                        IDCauhoi = c.Int(nullable: false),
                        Image = c.String(),
                        Trangthai = c.Boolean(nullable: false),
                        Ngaytao = c.DateTime(),
                        Nguoitao = c.String(maxLength: 256),
                        Ngaysua = c.DateTime(),
                        Nguoisua = c.String(maxLength: 256),
                        Ghichu = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Dethi",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ten = c.String(nullable: false, maxLength: 200),
                        Seo = c.String(maxLength: 200),
                        Mota = c.String(storeType: "ntext"),
                        Image = c.String(maxLength: 500),
                        Thoigianlambai = c.Int(nullable: false),
                        Tag = c.String(maxLength: 200, unicode: false),
                        HomeFlag = c.Boolean(nullable: false),
                        Trangthai = c.Boolean(nullable: false),
                        Ngaytao = c.DateTime(),
                        Nguoitao = c.String(maxLength: 256),
                        Ngaysua = c.DateTime(),
                        Nguoisua = c.String(maxLength: 256),
                        Ghichu = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ChudeDethi",
                c => new
                    {
                        IDChude = c.Int(nullable: false),
                        IDDethi = c.Int(nullable: false),
                        Trangthai = c.Boolean(nullable: false),
                        Ngaytao = c.DateTime(),
                        Nguoitao = c.String(maxLength: 256),
                        Ngaysua = c.DateTime(),
                        Nguoisua = c.String(maxLength: 256),
                        Ghichu = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => new { t.IDChude, t.IDDethi });
            
            CreateTable(
                "dbo.ChudeCauhoi",
                c => new
                    {
                        IDChude = c.Int(nullable: false),
                        IDCauhoi = c.Int(nullable: false),
                        Thutu = c.Int(nullable: false),
                        Trangthai = c.Boolean(nullable: false),
                        Ngaytao = c.DateTime(),
                        Nguoitao = c.String(maxLength: 256),
                        Ngaysua = c.DateTime(),
                        Nguoisua = c.String(maxLength: 256),
                        Ghichu = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => new { t.IDChude, t.IDCauhoi });
            
            CreateTable(
                "dbo.Chude",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ten = c.String(nullable: false, maxLength: 200),
                        IDChudeCha = c.Int(),
                        Tag = c.String(maxLength: 200, unicode: false),
                        Seo = c.String(maxLength: 200),
                        Mota = c.String(maxLength: 1000),
                        Image = c.String(maxLength: 256),
                        HomeFlag = c.Boolean(nullable: false),
                        Trangthai = c.Boolean(nullable: false),
                        Ngaytao = c.DateTime(),
                        Nguoitao = c.String(maxLength: 256),
                        Ngaysua = c.DateTime(),
                        Nguoisua = c.String(maxLength: 256),
                        Ghichu = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Cauhoi",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Noidung = c.String(nullable: false),
                        Noidunghienthi = c.String(nullable: false, storeType: "ntext"),
                        Goiy = c.String(maxLength: 1000),
                        Image = c.String(maxLength: 256),
                        Tag = c.String(maxLength: 200, unicode: false),
                        Trangthai = c.Boolean(nullable: false),
                        Ngaytao = c.DateTime(),
                        Nguoitao = c.String(maxLength: 256),
                        Ngaysua = c.DateTime(),
                        Nguoisua = c.String(maxLength: 256),
                        Ghichu = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID);
            
            DropForeignKey("dbo.ExamTopics", "TopicID", "dbo.Topics");
            DropForeignKey("dbo.ExamTopics", "ExamID", "dbo.Exams");
            DropForeignKey("dbo.ExamDetail", "QuestionID", "dbo.Questions");
            DropForeignKey("dbo.ExamDetail", "ExamID", "dbo.Exams");
            DropForeignKey("dbo.Answers", "QuestionID", "dbo.Questions");
            DropForeignKey("dbo.Questions", "TopicID", "dbo.Topics");
            DropIndex("dbo.ExamTopics", new[] { "ExamID" });
            DropIndex("dbo.ExamTopics", new[] { "TopicID" });
            DropIndex("dbo.ExamDetail", new[] { "QuestionID" });
            DropIndex("dbo.ExamDetail", new[] { "ExamID" });
            DropIndex("dbo.Questions", new[] { "TopicID" });
            DropIndex("dbo.Answers", new[] { "QuestionID" });
            DropTable("dbo.ExamTopics");
            DropTable("dbo.ExamDetail");
            DropTable("dbo.Exams");
            DropTable("dbo.Topics");
            DropTable("dbo.Questions");
            DropTable("dbo.Answers");
            CreateIndex("dbo.DethiCauhoi", "IDCauhoi");
            CreateIndex("dbo.DethiCauhoi", "IDDethi");
            CreateIndex("dbo.Dapan", "IDCauhoi");
            CreateIndex("dbo.ChudeDethi", "IDDethi");
            CreateIndex("dbo.ChudeDethi", "IDChude");
            CreateIndex("dbo.ChudeCauhoi", "IDCauhoi");
            CreateIndex("dbo.ChudeCauhoi", "IDChude");
            AddForeignKey("dbo.DethiCauhoi", "IDDethi", "dbo.Dethi", "ID", cascadeDelete: true);
            AddForeignKey("dbo.DethiCauhoi", "IDCauhoi", "dbo.Cauhoi", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Dapan", "IDCauhoi", "dbo.Cauhoi", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ChudeDethi", "IDDethi", "dbo.Dethi", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ChudeDethi", "IDChude", "dbo.Chude", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ChudeCauhoi", "IDChude", "dbo.Chude", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ChudeCauhoi", "IDCauhoi", "dbo.Cauhoi", "ID", cascadeDelete: true);
        }
    }
}
