namespace LuyenThi.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CauHoi",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Noidung = c.String(nullable: false, maxLength: 2000),
                        Photo = c.String(maxLength: 256),
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
                        Ngaytao = c.DateTime(),
                        Nguoitao = c.String(maxLength: 256),
                        Ngaysua = c.DateTime(),
                        Nguoisua = c.String(maxLength: 256),
                        Ghichu = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => new { t.IDChude, t.IDCauhoi })
                .ForeignKey("dbo.CauHoi", t => t.IDCauhoi, cascadeDelete: true)
                .ForeignKey("dbo.Chude", t => t.IDChude, cascadeDelete: true)
                .Index(t => t.IDChude)
                .Index(t => t.IDCauhoi);
            
            CreateTable(
                "dbo.ChudeDethi",
                c => new
                    {
                        IDChude = c.Int(nullable: false),
                        IDDethi = c.Int(nullable: false),
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
                        Ngaytao = c.DateTime(),
                        Nguoitao = c.String(maxLength: 256),
                        Ngaysua = c.DateTime(),
                        Nguoisua = c.String(maxLength: 256),
                        Ghichu = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CauHoi", t => t.IDCauhoi, cascadeDelete: true)
                .Index(t => t.IDCauhoi);
            
            CreateTable(
                "dbo.DethiCauHoi",
                c => new
                    {
                        IDDethi = c.Int(nullable: false),
                        IDCauhoi = c.Int(nullable: false),
                        Thutu = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IDDethi, t.IDCauhoi })
                .ForeignKey("dbo.CauHoi", t => t.IDCauhoi, cascadeDelete: true)
                .ForeignKey("dbo.Dethi", t => t.IDDethi, cascadeDelete: true)
                .Index(t => t.IDDethi)
                .Index(t => t.IDCauhoi);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DethiCauHoi", "IDDethi", "dbo.Dethi");
            DropForeignKey("dbo.DethiCauHoi", "IDCauhoi", "dbo.CauHoi");
            DropForeignKey("dbo.Dapan", "IDCauhoi", "dbo.CauHoi");
            DropForeignKey("dbo.ChudeDethi", "IDDethi", "dbo.Dethi");
            DropForeignKey("dbo.ChudeDethi", "IDChude", "dbo.Chude");
            DropForeignKey("dbo.ChudeCauhoi", "IDChude", "dbo.Chude");
            DropForeignKey("dbo.ChudeCauhoi", "IDCauhoi", "dbo.CauHoi");
            DropIndex("dbo.DethiCauHoi", new[] { "IDCauhoi" });
            DropIndex("dbo.DethiCauHoi", new[] { "IDDethi" });
            DropIndex("dbo.Dapan", new[] { "IDCauhoi" });
            DropIndex("dbo.ChudeDethi", new[] { "IDDethi" });
            DropIndex("dbo.ChudeDethi", new[] { "IDChude" });
            DropIndex("dbo.ChudeCauhoi", new[] { "IDCauhoi" });
            DropIndex("dbo.ChudeCauhoi", new[] { "IDChude" });
            DropTable("dbo.DethiCauHoi");
            DropTable("dbo.Dapan");
            DropTable("dbo.Dethi");
            DropTable("dbo.ChudeDethi");
            DropTable("dbo.ChudeCauhoi");
            DropTable("dbo.CauHoi");
        }
    }
}
