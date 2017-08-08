namespace LuyenThi.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumntoChude : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Chude", "IDChudeCha", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Chude", "IDChudeCha");
        }
    }
}
