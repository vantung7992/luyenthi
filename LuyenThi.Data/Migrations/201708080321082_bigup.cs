namespace LuyenThi.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bigup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cauhoi", "Gioiy", c => c.String(storeType: "ntext"));
            AddColumn("dbo.Chude", "Seo", c => c.String(maxLength: 200));
            AddColumn("dbo.Chude", "Mota", c => c.String(maxLength: 1000));
            AddColumn("dbo.Dethi", "Seo", c => c.String(maxLength: 200));
            AddColumn("dbo.Dethi", "Mota", c => c.String(maxLength: 500));
            AlterColumn("dbo.Cauhoi", "Noidung", c => c.String(nullable: false, storeType: "ntext"));
            AlterColumn("dbo.Cauhoi", "Tag", c => c.String(maxLength: 200, unicode: false));
            AlterColumn("dbo.Cauhoi", "Ghichu", c => c.String(maxLength: 500));
            AlterColumn("dbo.Chude", "IDChudeCha", c => c.Int());
            AlterColumn("dbo.Chude", "Tag", c => c.String(maxLength: 200, unicode: false));
            AlterColumn("dbo.Chude", "Ghichu", c => c.String(maxLength: 500));
            AlterColumn("dbo.ChudeCauhoi", "Ghichu", c => c.String(maxLength: 500));
            AlterColumn("dbo.ChudeDethi", "Ghichu", c => c.String(maxLength: 500));
            AlterColumn("dbo.Dethi", "Tag", c => c.String(maxLength: 200, unicode: false));
            AlterColumn("dbo.Dethi", "Ghichu", c => c.String(maxLength: 500));
            AlterColumn("dbo.Dapan", "Ghichu", c => c.String(maxLength: 500));
            AlterColumn("dbo.DethiCauhoi", "Ghichu", c => c.String(maxLength: 500));
            DropColumn("dbo.ChudeCauhoi", "Tag");
            DropColumn("dbo.ChudeDethi", "Tag");
            DropColumn("dbo.Dapan", "Tag");
            DropColumn("dbo.DethiCauhoi", "Tag");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DethiCauhoi", "Tag", c => c.String());
            AddColumn("dbo.Dapan", "Tag", c => c.String());
            AddColumn("dbo.ChudeDethi", "Tag", c => c.String());
            AddColumn("dbo.ChudeCauhoi", "Tag", c => c.String());
            AlterColumn("dbo.DethiCauhoi", "Ghichu", c => c.String(maxLength: 1000));
            AlterColumn("dbo.Dapan", "Ghichu", c => c.String(maxLength: 1000));
            AlterColumn("dbo.Dethi", "Ghichu", c => c.String(maxLength: 1000));
            AlterColumn("dbo.Dethi", "Tag", c => c.String());
            AlterColumn("dbo.ChudeDethi", "Ghichu", c => c.String(maxLength: 1000));
            AlterColumn("dbo.ChudeCauhoi", "Ghichu", c => c.String(maxLength: 1000));
            AlterColumn("dbo.Chude", "Ghichu", c => c.String(maxLength: 1000));
            AlterColumn("dbo.Chude", "Tag", c => c.String());
            AlterColumn("dbo.Chude", "IDChudeCha", c => c.Int(nullable: false));
            AlterColumn("dbo.Cauhoi", "Ghichu", c => c.String(maxLength: 1000));
            AlterColumn("dbo.Cauhoi", "Tag", c => c.String());
            AlterColumn("dbo.Cauhoi", "Noidung", c => c.String(nullable: false, maxLength: 2000));
            DropColumn("dbo.Dethi", "Mota");
            DropColumn("dbo.Dethi", "Seo");
            DropColumn("dbo.Chude", "Mota");
            DropColumn("dbo.Chude", "Seo");
            DropColumn("dbo.Cauhoi", "Gioiy");
        }
    }
}
