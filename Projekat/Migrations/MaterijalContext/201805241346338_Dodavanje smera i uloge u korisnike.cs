namespace Projekat.Migrations.MaterijalContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dodavanjesmeraiulogeukorisnike : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "SmerId", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Uloga", c => c.String());
            AlterColumn("dbo.AspNetUsers", "SkolaId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "SkolaId", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "Uloga");
            DropColumn("dbo.AspNetUsers", "SmerId");
        }
    }
}
