namespace LuyenThi.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThemThoigianlambai : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dethi", "Thoigianlambai", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dethi", "Thoigianlambai");
        }
    }
}
