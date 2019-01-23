namespace Projekat.Migrations.MaterijalContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodavanjeGodineupisaskoleistrucnespreme : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SkolaModels",
                c => new
                    {
                        IdSkole = c.Int(nullable: false, identity: true),
                        NazivSkole = c.String(),
                        Skraceno = c.String(),
                    })
                .PrimaryKey(t => t.IdSkole);
            
            CreateTable(
                "dbo.StrucnaSpremaModels",
                c => new
                    {
                        IdSS = c.Int(nullable: false, identity: false),
                        NazivSS = c.String(),
                        SkracenoSS = c.String(),
                    })
                .PrimaryKey(t => t.IdSS);
            
            AddColumn("dbo.AspNetUsers", "SkolaId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "GodinaUpisa", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "GodinaUpisa");
            DropColumn("dbo.AspNetUsers", "SkolaId");
            DropTable("dbo.StrucnaSpremaModels");
            DropTable("dbo.SkolaModels");
        }
    }
}
