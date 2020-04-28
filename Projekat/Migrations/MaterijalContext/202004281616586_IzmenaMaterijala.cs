namespace Projekat.Migrations.MaterijalContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IzmenaMaterijala : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MaterijalModels", "predmetId", "dbo.PredmetModels");
            DropIndex("dbo.MaterijalModels", new[] { "predmetId" });
            DropColumn("dbo.MaterijalModels", "predmetId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MaterijalModels", "predmetId", c => c.Int());
            CreateIndex("dbo.MaterijalModels", "predmetId");
            AddForeignKey("dbo.MaterijalModels", "predmetId", "dbo.PredmetModels", "predmetId");
        }
    }
}
