namespace LuyenThi.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeDescriptionField : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Topics", "Description", c => c.String(storeType: "ntext"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Topics", "Description", c => c.String(maxLength: 500));
        }
    }
}
