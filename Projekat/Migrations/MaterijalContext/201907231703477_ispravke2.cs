namespace Projekat.Migrations.MaterijalContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ispravke2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MaterijalProfesorModels", "predmetId", c => c.Int(nullable: true));
            
        }
        
        public override void Down()
        {
            
        }
    }
}
