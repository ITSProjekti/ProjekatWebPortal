namespace Projekat.Migrations.MaterijalContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Brisanjesrucnespreme : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.StrucnaSpremaModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.StrucnaSpremaModels",
                c => new
                    {
                        IdSS = c.Int(nullable: false),
                        NazivSS = c.String(),
                        SkracenoSS = c.String(),
                    })
                .PrimaryKey(t => t.IdSS);
            
        }
    }
}
