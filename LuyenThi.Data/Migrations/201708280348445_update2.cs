namespace LuyenThi.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cauhoi", "Goiy", c => c.String(storeType: "ntext"));
            DropColumn("dbo.Cauhoi", "Gioiy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cauhoi", "Gioiy", c => c.String(storeType: "ntext"));
            DropColumn("dbo.Cauhoi", "Goiy");
        }
    }
}
