namespace Projekat.Migrations.MaterijalContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodavanjeModula : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ModulModels", "modulNaziv", c => c.String(maxLength: 50));
            AlterColumn("dbo.ModulModels", "modulOpis", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ModulModels", "modulOpis", c => c.String());
            AlterColumn("dbo.ModulModels", "modulNaziv", c => c.String());
        }
    }
}
