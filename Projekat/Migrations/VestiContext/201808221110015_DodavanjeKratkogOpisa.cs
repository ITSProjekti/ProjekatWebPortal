namespace Projekat.Migrations.VestiContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodavanjeKratkogOpisa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VestModels", "KratakOpis", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.VestModels", "KratakOpis");
        }
    }
}
