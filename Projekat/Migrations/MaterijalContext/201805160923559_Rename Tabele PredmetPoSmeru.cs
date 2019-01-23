namespace Projekat.Migrations.MaterijalContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameTabelePredmetPoSmeru : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PremetPoSmerus", newName: "PredmetPoSmerus");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.PredmetPoSmerus", newName: "PremetPoSmerus");
        }
    }
}
