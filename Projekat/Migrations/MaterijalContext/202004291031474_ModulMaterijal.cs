namespace Projekat.Migrations.MaterijalContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModulMaterijal : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MaterijalModels", "modulId", "dbo.ModulModels");
            DropIndex("dbo.MaterijalModels", new[] { "modulId" });
            CreateTable(
                "dbo.MaterijalPoModulus",
                c => new
                    {
                        modulId = c.Int(nullable: false),
                        materijalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.modulId, t.materijalId })
                .ForeignKey("dbo.MaterijalModels", t => t.materijalId, cascadeDelete: true)
                .ForeignKey("dbo.ModulModels", t => t.modulId, cascadeDelete: true)
                .Index(t => t.modulId)
                .Index(t => t.materijalId);
            
            DropColumn("dbo.MaterijalModels", "modulId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MaterijalModels", "modulId", c => c.Int());
            DropForeignKey("dbo.MaterijalPoModulus", "modulId", "dbo.ModulModels");
            DropForeignKey("dbo.MaterijalPoModulus", "materijalId", "dbo.MaterijalModels");
            DropIndex("dbo.MaterijalPoModulus", new[] { "materijalId" });
            DropIndex("dbo.MaterijalPoModulus", new[] { "modulId" });
            DropTable("dbo.MaterijalPoModulus");
            CreateIndex("dbo.MaterijalModels", "modulId");
            AddForeignKey("dbo.MaterijalModels", "modulId", "dbo.ModulModels", "modulId");
        }
    }
}
