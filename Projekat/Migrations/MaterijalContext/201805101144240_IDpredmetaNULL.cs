namespace Projekat.Migrations.MaterijalContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IDpredmetaNULL : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MaterijalModels", "predmetId", "dbo.PredmetModels");
            DropIndex("dbo.MaterijalModels", new[] { "predmetId" });
            AlterColumn("dbo.MaterijalModels", "predmetId", c => c.Int());
            CreateIndex("dbo.MaterijalModels", "predmetId");
            AddForeignKey("dbo.MaterijalModels", "predmetId", "dbo.PredmetModels", "predmetId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MaterijalModels", "predmetId", "dbo.PredmetModels");
            DropIndex("dbo.MaterijalModels", new[] { "predmetId" });
            AlterColumn("dbo.MaterijalModels", "predmetId", c => c.Int(nullable: false));
            CreateIndex("dbo.MaterijalModels", "predmetId");
            AddForeignKey("dbo.MaterijalModels", "predmetId", "dbo.PredmetModels", "predmetId", cascadeDelete: true);
        }
    }
}
