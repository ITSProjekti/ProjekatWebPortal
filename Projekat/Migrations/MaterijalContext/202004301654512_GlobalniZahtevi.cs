namespace Projekat.Migrations.MaterijalContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GlobalniZahtevi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GlobalniZahteviModels",
                c => new
                    {
                        zahtevId = c.Int(nullable: false, identity: true),
                        zahtevDatum = c.DateTime(nullable: false),
                        zahtevObrazlozenje = c.String(),
                        materijalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.zahtevId)
                .ForeignKey("dbo.MaterijalModels", t => t.materijalId, cascadeDelete: true)
                .Index(t => t.materijalId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GlobalniZahteviModels", "materijalId", "dbo.MaterijalModels");
            DropIndex("dbo.GlobalniZahteviModels", new[] { "materijalId" });
            DropTable("dbo.GlobalniZahteviModels");
        }
    }
}
