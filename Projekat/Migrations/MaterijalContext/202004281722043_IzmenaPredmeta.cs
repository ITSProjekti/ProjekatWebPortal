namespace Projekat.Migrations.MaterijalContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IzmenaPredmeta : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TipPredmetaModels",
                c => new
                    {
                        tipId = c.Int(nullable: false, identity: true),
                        tipNaziv = c.String(),
                    })
                .PrimaryKey(t => t.tipId);
            
            AddColumn("dbo.PredmetModels", "tipId", c => c.Int(nullable: false));
            CreateIndex("dbo.PredmetModels", "tipId");
            AddForeignKey("dbo.PredmetModels", "tipId", "dbo.TipPredmetaModels", "tipId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PredmetModels", "tipId", "dbo.TipPredmetaModels");
            DropIndex("dbo.PredmetModels", new[] { "tipId" });
            DropColumn("dbo.PredmetModels", "tipId");
            DropTable("dbo.TipPredmetaModels");
        }
    }
}
