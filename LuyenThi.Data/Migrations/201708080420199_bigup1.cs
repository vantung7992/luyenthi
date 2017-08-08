namespace LuyenThi.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bigup1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cauhoi", "Image", c => c.String(maxLength: 256));
            AddColumn("dbo.Chude", "Image", c => c.String(maxLength: 256));
            AddColumn("dbo.Dapan", "Image", c => c.String());
            DropColumn("dbo.Cauhoi", "Photo");
            DropColumn("dbo.Dapan", "Photo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Dapan", "Photo", c => c.String());
            AddColumn("dbo.Cauhoi", "Photo", c => c.String(maxLength: 256));
            DropColumn("dbo.Dapan", "Image");
            DropColumn("dbo.Chude", "Image");
            DropColumn("dbo.Cauhoi", "Image");
        }
    }
}
