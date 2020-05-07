namespace Projekat.Migrations.MaterijalContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GlobalniZahtevi1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GlobalniZahteviModels", "ZaGlobalnog", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GlobalniZahteviModels", "ZaGlobalnog");
        }
    }
}
