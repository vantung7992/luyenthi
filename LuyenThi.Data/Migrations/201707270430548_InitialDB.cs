namespace LuyenThi.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cauhoi",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Noidung = c.String(nullable: false, maxLength: 2000),
                        Photo = c.String(maxLength: 256),
                        Nhan = c.String(),
                        Trangthai = c.Boolean(nullable: false),
                        Ngaytao = c.DateTime(),
                        Nguoitao = c.String(maxLength: 256),
                        Ngaysua = c.DateTime(),
                        Nguoisua = c.String(maxLength: 256),
                        Ghichu = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Chude",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ten = c.String(nullable: false, maxLength: 200),
                        Nhan = c.String(),
                        Trangthai = c.Boolean(nullable: false),
                        Ngaytao = c.DateTime(),
                        Nguoitao = c.String(maxLength: 256),
                        Ngaysua = c.DateTime(),
                        Nguoisua = c.String(maxLength: 256),
                        Ghichu = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ChudeCauhoi",
                c => new
                    {
                        IDChude = c.Int(nullable: false),
                        IDCauhoi = c.Int(nullable: false),
                        Thutu = c.Int(nullable: false),
                        Nhan = c.String(),
                        Trangthai = c.Boolean(nullable: false),
                        Ngaytao = c.DateTime(),
                        Nguoitao = c.String(maxLength: 256),
                        Ngaysua = c.DateTime(),
                        Nguoisua = c.String(maxLength: 256),
                        Ghichu = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => new { t.IDChude, t.IDCauhoi })
                .ForeignKey("dbo.Cauhoi", t => t.IDCauhoi, cascadeDelete: true)
                .ForeignKey("dbo.Chude", t => t.IDChude, cascadeDelete: true)
                .Index(t => t.IDChude)
                .Index(t => t.IDCauhoi);
            
            CreateTable(
                "dbo.ChudeDethi",
                c => new
                    {
                        IDChude = c.Int(nullable: false),
                        IDDethi = c.Int(nullable: false),
                        Nhan = c.String(),
                        Trangthai = c.Boolean(nullable: false),
                        Ngaytao = c.DateTime(),
                        Nguoitao = c.String(maxLength: 256),
                        Ngaysua = c.DateTime(),
                        Nguoisua = c.String(maxLength: 256),
                        Ghichu = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => new { t.IDChude, t.IDDethi })
                .ForeignKey("dbo.Chude", t => t.IDChude, cascadeDelete: true)
                .ForeignKey("dbo.Dethi", t => t.IDDethi, cascadeDelete: true)
                .Index(t => t.IDChude)
                .Index(t => t.IDDethi);
            
            CreateTable(
                "dbo.Dethi",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ten = c.String(nullable: false, maxLength: 200),
                        Nhan = c.String(),
                        Trangthai = c.Boolean(nullable: false),
                        Ngaytao = c.DateTime(),
                        Nguoitao = c.String(maxLength: 256),
                        Ngaysua = c.DateTime(),
                        Nguoisua = c.String(maxLength: 256),
                        Ghichu = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.ID);
            
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
                        Photo = c.String(),
                        Nhan = c.String(),
                        Trangthai = c.Boolean(nullable: false),
                        Ngaytao = c.DateTime(),
                        Nguoitao = c.String(maxLength: 256),
                        Ngaysua = c.DateTime(),
                        Nguoisua = c.String(maxLength: 256),
                        Ghichu = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cauhoi", t => t.IDCauhoi, cascadeDelete: true)
                .Index(t => t.IDCauhoi);
            
            CreateTable(
                "dbo.DethiCauhoi",
                c => new
                    {
                        IDDethi = c.Int(nullable: false),
                        IDCauhoi = c.Int(nullable: false),
                        Thutu = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IDDethi, t.IDCauhoi })
                .ForeignKey("dbo.Cauhoi", t => t.IDCauhoi, cascadeDelete: true)
                .ForeignKey("dbo.Dethi", t => t.IDDethi, cascadeDelete: true)
                .Index(t => t.IDDethi)
                .Index(t => t.IDCauhoi);
            
            CreateTable(
                "dbo.Errors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        StackTrace = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DethiCauhoi", "IDDethi", "dbo.Dethi");
            DropForeignKey("dbo.DethiCauhoi", "IDCauhoi", "dbo.Cauhoi");
            DropForeignKey("dbo.Dapan", "IDCauhoi", "dbo.Cauhoi");
            DropForeignKey("dbo.ChudeDethi", "IDDethi", "dbo.Dethi");
            DropForeignKey("dbo.ChudeDethi", "IDChude", "dbo.Chude");
            DropForeignKey("dbo.ChudeCauhoi", "IDChude", "dbo.Chude");
            DropForeignKey("dbo.ChudeCauhoi", "IDCauhoi", "dbo.Cauhoi");
            DropIndex("dbo.DethiCauhoi", new[] { "IDCauhoi" });
            DropIndex("dbo.DethiCauhoi", new[] { "IDDethi" });
            DropIndex("dbo.Dapan", new[] { "IDCauhoi" });
            DropIndex("dbo.ChudeDethi", new[] { "IDDethi" });
            DropIndex("dbo.ChudeDethi", new[] { "IDChude" });
            DropIndex("dbo.ChudeCauhoi", new[] { "IDCauhoi" });
            DropIndex("dbo.ChudeCauhoi", new[] { "IDChude" });
            DropTable("dbo.Errors");
            DropTable("dbo.DethiCauhoi");
            DropTable("dbo.Dapan");
            DropTable("dbo.Dethi");
            DropTable("dbo.ChudeDethi");
            DropTable("dbo.ChudeCauhoi");
            DropTable("dbo.Chude");
            DropTable("dbo.Cauhoi");
        }
    }
}
