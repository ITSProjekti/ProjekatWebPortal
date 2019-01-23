namespace Projekat.Migrations.VestiContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TeloVestiZasebnaTabela : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TeloVestiModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VestId = c.Int(nullable: false),
                        TeloVesti = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VestModels", t => t.VestId, cascadeDelete: true)
                .Index(t => t.VestId);
            
            DropColumn("dbo.VestModels", "Vest");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VestModels", "Vest", c => c.String());
            DropForeignKey("dbo.TeloVestiModels", "VestId", "dbo.VestModels");
            DropIndex("dbo.TeloVestiModels", new[] { "VestId" });
            DropTable("dbo.TeloVestiModels");
        }
    }
}
