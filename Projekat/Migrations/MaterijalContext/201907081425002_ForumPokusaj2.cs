namespace Projekat.Migrations.MaterijalContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForumPokusaj2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Forum_Posts",
                c => new
                {
                    Id_post = c.Int(nullable: false, identity: true),
                    posttitle = c.String(),
                    postmessage = c.String(),
                    posteddate = c.DateTime(defaultValue: DateTime.Now),
                    approved = c.String(),
                    Id = c.String(nullable: false,maxLength:128),
                })
                .PrimaryKey(t => t.Id_post)
                .ForeignKey("dbo.AspNetUsers", t => t.Id, cascadeDelete: true);

        }

        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Id", "dbo.Forum_Posts");
            DropTable("dbo.Forum_Posts");
        }
    }
}
