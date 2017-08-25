namespace LuyenThi.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcolumnHomeflag : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Chude", "HomeFlag", c => c.Boolean(nullable: false));
            AddColumn("dbo.Dethi", "HomeFlag", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dethi", "HomeFlag");
            DropColumn("dbo.Chude", "HomeFlag");
        }
    }
}
