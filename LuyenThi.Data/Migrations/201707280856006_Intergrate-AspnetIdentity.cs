namespace LuyenThi.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntergrateAspnetIdentity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRoles", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Hoten = c.String(maxLength: 256),
                        Diachi = c.String(maxLength: 256),
                        Ngaysinh = c.DateTime(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            AddColumn("dbo.Cauhoi", "Tag", c => c.String());
            AddColumn("dbo.Chude", "Tag", c => c.String());
            AddColumn("dbo.ChudeCauhoi", "Tag", c => c.String());
            AddColumn("dbo.ChudeDethi", "Tag", c => c.String());
            AddColumn("dbo.Dethi", "Tag", c => c.String());
            AddColumn("dbo.Dapan", "Tag", c => c.String());
            AddColumn("dbo.DethiCauhoi", "Tag", c => c.String());
            AddColumn("dbo.DethiCauhoi", "Trangthai", c => c.Boolean(nullable: false));
            AddColumn("dbo.DethiCauhoi", "Ngaytao", c => c.DateTime());
            AddColumn("dbo.DethiCauhoi", "Nguoitao", c => c.String(maxLength: 256));
            AddColumn("dbo.DethiCauhoi", "Ngaysua", c => c.DateTime());
            AddColumn("dbo.DethiCauhoi", "Nguoisua", c => c.String(maxLength: 256));
            AddColumn("dbo.DethiCauhoi", "Ghichu", c => c.String(maxLength: 1000));
            DropColumn("dbo.Cauhoi", "Nhan");
            DropColumn("dbo.Chude", "Nhan");
            DropColumn("dbo.ChudeCauhoi", "Nhan");
            DropColumn("dbo.ChudeDethi", "Nhan");
            DropColumn("dbo.Dethi", "Nhan");
            DropColumn("dbo.Dapan", "Nhan");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Dapan", "Nhan", c => c.String());
            AddColumn("dbo.Dethi", "Nhan", c => c.String());
            AddColumn("dbo.ChudeDethi", "Nhan", c => c.String());
            AddColumn("dbo.ChudeCauhoi", "Nhan", c => c.String());
            AddColumn("dbo.Chude", "Nhan", c => c.String());
            AddColumn("dbo.Cauhoi", "Nhan", c => c.String());
            DropForeignKey("dbo.IdentityUserRoles", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserLogins", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserClaims", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropIndex("dbo.IdentityUserLogins", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropColumn("dbo.DethiCauhoi", "Ghichu");
            DropColumn("dbo.DethiCauhoi", "Nguoisua");
            DropColumn("dbo.DethiCauhoi", "Ngaysua");
            DropColumn("dbo.DethiCauhoi", "Nguoitao");
            DropColumn("dbo.DethiCauhoi", "Ngaytao");
            DropColumn("dbo.DethiCauhoi", "Trangthai");
            DropColumn("dbo.DethiCauhoi", "Tag");
            DropColumn("dbo.Dapan", "Tag");
            DropColumn("dbo.Dethi", "Tag");
            DropColumn("dbo.ChudeDethi", "Tag");
            DropColumn("dbo.ChudeCauhoi", "Tag");
            DropColumn("dbo.Chude", "Tag");
            DropColumn("dbo.Cauhoi", "Tag");
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.ApplicationUsers");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityRoles");
        }
    }
}
