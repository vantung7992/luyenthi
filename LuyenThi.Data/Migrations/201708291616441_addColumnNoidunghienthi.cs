namespace LuyenThi.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColumnNoidunghienthi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cauhoi", "Noidunghienthi", c => c.String(nullable: false, storeType: "ntext"));
            AlterColumn("dbo.Cauhoi", "Noidung", c => c.String(nullable: false));
            AlterColumn("dbo.Cauhoi", "Goiy", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cauhoi", "Goiy", c => c.String(storeType: "ntext"));
            AlterColumn("dbo.Cauhoi", "Noidung", c => c.String(nullable: false, storeType: "ntext"));
            DropColumn("dbo.Cauhoi", "Noidunghienthi");
        }
    }
}
