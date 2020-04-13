namespace Projekat.Migrations.MaterijalContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodavanjeModula : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ModulModels",
                c => new
                    {
                        modulId = c.Int(nullable: false, identity: true),
                        modulNaziv = c.String(maxLength: 50),
                        modulOpis = c.String(maxLength: 250),
                        predmetId = c.Int(),
                    })
                .PrimaryKey(t => t.modulId)
                .ForeignKey("dbo.PredmetModels", t => t.predmetId)
                .Index(t => t.predmetId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ModulModels", "predmetId", "dbo.PredmetModels");
            DropIndex("dbo.ModulModels", new[] { "predmetId" });
            DropTable("dbo.ModulModels");
        }
    }
}
