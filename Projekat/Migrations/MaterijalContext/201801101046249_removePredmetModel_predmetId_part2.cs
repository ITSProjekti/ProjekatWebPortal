namespace Projekat.Migrations.MaterijalContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removePredmetModel_predmetId_part2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("PredmetModels", new[] { "StatusId" });
           // DropColumn("PredmetModels", "PredmetModel_predmetId");
        }
        
        public override void Down()
        {
        }
    }
}
