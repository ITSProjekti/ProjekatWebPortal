namespace Projekat.Migrations.MaterijalContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IspravkaMaterijala : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MaterijalModels", "modulId", c => c.Int());
            CreateIndex("dbo.MaterijalModels", "modulId");
            AddForeignKey("dbo.MaterijalModels", "modulId", "dbo.ModulModels", "modulId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MaterijalModels", "modulId", "dbo.ModulModels");
            DropIndex("dbo.MaterijalModels", new[] { "modulId" });
            DropColumn("dbo.MaterijalModels", "modulId");
        }
    }
}
