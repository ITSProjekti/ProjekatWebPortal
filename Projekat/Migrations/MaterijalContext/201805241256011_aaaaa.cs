namespace Projekat.Migrations.MaterijalContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aaaaa : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.StrucnaSpremaModels");
            AlterColumn("dbo.StrucnaSpremaModels", "IdSS", c => c.Int(nullable: false,identity:false));
            AddPrimaryKey("dbo.StrucnaSpremaModels", "IdSS");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.StrucnaSpremaModels");
            AlterColumn("dbo.StrucnaSpremaModels", "IdSS", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.StrucnaSpremaModels", "IdSS");
        }
    }
}
