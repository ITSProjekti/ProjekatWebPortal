namespace Projekat.Migrations.MaterijalContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MaterijalModels",
                c => new
                    {
                        materijalId = c.Int(nullable: false, identity: true),
                        materijalFile = c.Binary(),
                        fileMimeType = c.String(),
                        materijalOpis = c.String(),
                        materijalEkstenzija = c.String(),
                        materijalNaziv = c.String(),
                        materijalNaslov = c.String(),
                        predmetId = c.Int(nullable: false),
                        tipMaterijalId = c.Int(nullable: false),
                        namenaMaterijalaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.materijalId)
                .ForeignKey("dbo.NamenaMaterijalaModels", t => t.namenaMaterijalaId, cascadeDelete: true)
                .ForeignKey("dbo.PredmetModels", t => t.predmetId, cascadeDelete: true)
                .ForeignKey("dbo.TipMaterijalModels", t => t.tipMaterijalId, cascadeDelete: true)
                .Index(t => t.predmetId)
                .Index(t => t.tipMaterijalId)
                .Index(t => t.namenaMaterijalaId);
            
            CreateTable(
                "dbo.NamenaMaterijalaModels",
                c => new
                    {
                        namenaMaterijalaId = c.Int(nullable: false, identity: false),
                        namenaMaterijalaNaziv = c.String(),
                    })
                .PrimaryKey(t => t.namenaMaterijalaId);
            
            CreateTable(
                "dbo.PredmetModels",
                c => new
                    {
                        predmetId = c.Int(nullable: false, identity: true),
                        predmetNaziv = c.String(),
                        predmetOpis = c.String(),
                    })
                .PrimaryKey(t => t.predmetId);
            
            CreateTable(
                "dbo.TipMaterijalModels",
                c => new
                    {
                        tipMaterijalId = c.Int(nullable: false, identity: true),
                        nazivTipMaterijal = c.String(),
                    })
                .PrimaryKey(t => t.tipMaterijalId);
            
            CreateTable(
                "dbo.PremetPoSmerus",
                c => new
                    {
                        predmetId = c.Int(nullable: false),
                        smerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.predmetId, t.smerId })
                .ForeignKey("dbo.PredmetModels", t => t.predmetId, cascadeDelete: true)
                .ForeignKey("dbo.SmerModels", t => t.smerId, cascadeDelete: true)
                .Index(t => t.predmetId)
                .Index(t => t.smerId);
            
            CreateTable(
                "dbo.SmerModels",
                c => new
                    {
                        smerId = c.Int(nullable: false, identity: true),
                        smerNaziv = c.String(),
                        smerOpis = c.String(),
                    })
                .PrimaryKey(t => t.smerId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PremetPoSmerus", "smerId", "dbo.SmerModels");
            DropForeignKey("dbo.PremetPoSmerus", "predmetId", "dbo.PredmetModels");
            DropForeignKey("dbo.MaterijalModels", "tipMaterijalId", "dbo.TipMaterijalModels");
            DropForeignKey("dbo.MaterijalModels", "predmetId", "dbo.PredmetModels");
            DropForeignKey("dbo.MaterijalModels", "namenaMaterijalaId", "dbo.NamenaMaterijalaModels");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PremetPoSmerus", new[] { "smerId" });
            DropIndex("dbo.PremetPoSmerus", new[] { "predmetId" });
            DropIndex("dbo.MaterijalModels", new[] { "namenaMaterijalaId" });
            DropIndex("dbo.MaterijalModels", new[] { "tipMaterijalId" });
            DropIndex("dbo.MaterijalModels", new[] { "predmetId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.SmerModels");
            DropTable("dbo.PremetPoSmerus");
            DropTable("dbo.TipMaterijalModels");
            DropTable("dbo.PredmetModels");
            DropTable("dbo.NamenaMaterijalaModels");
            DropTable("dbo.MaterijalModels");
        }
    }
}
