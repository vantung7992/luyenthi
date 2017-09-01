namespace LuyenThi.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMota : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dethi", "Image", c => c.String(maxLength: 500));
            AlterColumn("dbo.Dethi", "Mota", c => c.String(storeType: "ntext"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Dethi", "Mota", c => c.String(maxLength: 500));
            DropColumn("dbo.Dethi", "Image");
        }
    }
}
