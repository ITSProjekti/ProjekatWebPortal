namespace Projekat.Migrations.MaterijalContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaterijalModelProfesor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MaterijalProfesorModels",
                c => new
                    {
                        materijalId = c.Int(nullable: false, identity: true),
                        materijalFile = c.Binary(),
                        fileMimeType = c.String(),
                        materijalOpis = c.String(),
                        materijalEkstenzija = c.String(),
                        materijalNaziv = c.String(),
                        materijalNaslov = c.String(),
                        predmetId = c.Int(nullable: true),
                        tipMaterijalId = c.Int(nullable: true),
                        namenaMaterijalaId = c.Int(nullable: false),
                })
                     .PrimaryKey(t => t.materijalId)
                    .ForeignKey("dbo.NamenaMaterijalaModels", t => t.namenaMaterijalaId, cascadeDelete: true)
                    .ForeignKey("dbo.PredmetModels", t => t.predmetId, cascadeDelete: true)
                    .ForeignKey("dbo.TipMaterijalModels", t => t.tipMaterijalId, cascadeDelete: true)
                    .Index(t => t.predmetId)
                    .Index(t => t.tipMaterijalId)
                    .Index(t => t.namenaMaterijalaId);

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MaterijalProfesorModels", "tipMaterijalId", "dbo.TipMaterijalModels");
            DropForeignKey("dbo.MaterijalProfesorModels", "predmetId", "dbo.PredmetModels");
            DropForeignKey("dbo.MaterijalProfesorModels", "namenaMaterijalaId", "dbo.NamenaMaterijalaModels");
            DropIndex("dbo.MaterijalProfesorModels", new[] { "namenaMaterijalaId" });
            DropIndex("dbo.MaterijalProfesorModels", new[] { "tipMaterijalId" });
            DropIndex("dbo.MaterijalProfesorModels", new[] { "predmetId" });
        }
    }
}
