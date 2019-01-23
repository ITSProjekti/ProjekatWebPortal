namespace Projekat.Migrations.MaterijalContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JosNekaSredjivanja : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SmerModels", "smerSkraceno", c => c.String());
            AlterColumn("dbo.AspNetUsers", "GodinaUpisa", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "GodinaUpisa", c => c.Int(nullable: false));
            DropColumn("dbo.SmerModels", "smerSkraceno");
        }
    }
}
