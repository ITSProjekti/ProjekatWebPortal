namespace Projekat.Migrations.VestiContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodavanjeDatumaICuvaSePutDoSlike : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VestModels", "DatumPostavljanja", c => c.DateTime(nullable: false));
            AlterColumn("dbo.VestModels", "Thumbnail", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VestModels", "Thumbnail", c => c.Binary());
            DropColumn("dbo.VestModels", "DatumPostavljanja");
        }
    }
}
