namespace Projekat.Migrations.MaterijalContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class promene : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MaterijalModels", "namenaMaterijalaId", "dbo.NamenaMaterijalaModels");
            DropPrimaryKey("dbo.NamenaMaterijalaModels");
            AlterColumn("dbo.NamenaMaterijalaModels", "namenaMaterijalaId", c => c.Int(nullable: false,identity:false));
            AddPrimaryKey("dbo.NamenaMaterijalaModels", "namenaMaterijalaId");
            AddForeignKey("dbo.MaterijalModels", "namenaMaterijalaId", "dbo.NamenaMaterijalaModels", "namenaMaterijalaId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MaterijalModels", "namenaMaterijalaId", "dbo.NamenaMaterijalaModels");
            DropPrimaryKey("dbo.NamenaMaterijalaModels");
            AlterColumn("dbo.NamenaMaterijalaModels", "namenaMaterijalaId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.NamenaMaterijalaModels", "namenaMaterijalaId");
            AddForeignKey("dbo.MaterijalModels", "namenaMaterijalaId", "dbo.NamenaMaterijalaModels", "namenaMaterijalaId", cascadeDelete: true);
        }
    }
}
