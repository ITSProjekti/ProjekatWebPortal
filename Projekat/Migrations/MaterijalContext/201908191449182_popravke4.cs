namespace Projekat.Migrations.MaterijalContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class popravke4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MaterijalModels", "idUser", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MaterijalModels", "idUser");
        }
    }
}
