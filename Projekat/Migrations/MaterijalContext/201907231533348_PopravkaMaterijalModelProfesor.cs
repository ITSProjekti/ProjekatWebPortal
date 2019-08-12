namespace Projekat.Migrations.MaterijalContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopravkaMaterijalModelProfesor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MaterijalProfesorModels", "odobreno", c => c.String());
            AddColumn("dbo.MaterijalProfesorModels", "obrazlozenje", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MaterijalProfesorModels", "odobreno");
            DropColumn("dbo.MaterijalProfesorModels", "obrazlozenje");
        }
    }
}
