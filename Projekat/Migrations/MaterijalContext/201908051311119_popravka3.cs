namespace Projekat.Migrations.MaterijalContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class popravka3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MaterijalModels", "odobreno", c => c.String());
            AddColumn("dbo.MaterijalModels", "obrazlozenje", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.MaterijalProfesorModels", "odobreno");
            DropColumn("dbo.MaterijalProfesorModels", "obrazlozenje");
        }
    }
}
