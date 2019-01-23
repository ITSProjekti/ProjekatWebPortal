namespace Projekat.Migrations.VestiContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dodavanje_Vesti_U_Bazu : DbMigration
    {
        public override void Up()
        {
           
            
            CreateTable(
                "dbo.VestModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naslov = c.String(),
                        Thumbnail = c.Binary(),
                        Vest = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
           
            DropTable("dbo.VestModels");
           
        }
    }
}
