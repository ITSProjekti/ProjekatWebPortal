namespace Projekat.Migrations.MaterijalContext
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class MaterijalConfiguration : DbMigrationsConfiguration<Projekat.Models.MaterijalContext>
    {
        public MaterijalConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\MaterijalContext";
        }

        protected override void Seed(Projekat.Models.MaterijalContext context)
        {
            context.Roles.AddOrUpdate(x => x.Id,
                new Microsoft.AspNet.Identity.EntityFramework.IdentityRole() { Id = "5", Name = "SuperAdministrator" },
                new Microsoft.AspNet.Identity.EntityFramework.IdentityRole() { Id = "1", Name = "Administrator" },
                new Microsoft.AspNet.Identity.EntityFramework.IdentityRole() { Id = "2", Name = "Urednik" },
                new Microsoft.AspNet.Identity.EntityFramework.IdentityRole() { Id = "3", Name = "Profesor" },
                new Microsoft.AspNet.Identity.EntityFramework.IdentityRole() { Id = "4", Name = "Ucenik" }
            );
            context.nameneMaterijala.AddOrUpdate(x => x.namenaMaterijalaId,
            new Models.NamenaMaterijalaModel() { namenaMaterijalaId = 1, namenaMaterijalaNaziv = "Materijal za ucenike" },
            new Models.NamenaMaterijalaModel() { namenaMaterijalaId = 2, namenaMaterijalaNaziv = "Materijal za profesore" }
            );
            context.tipMaterijala.AddOrUpdate(x => x.tipMaterijalId,
                new Models.TipMaterijalModel() { tipMaterijalId = 1, nazivTipMaterijal = "Materijal sa vezbi" },
                new Models.TipMaterijalModel() { tipMaterijalId = 2, nazivTipMaterijal = "Materijal sa predavanja" },
                new Models.TipMaterijalModel() { tipMaterijalId = 3, nazivTipMaterijal = "Materijal za samostalan rad" }

            );
            context.Skole.AddOrUpdate(x => x.IdSkole,
                new Models.SkolaModel() { IdSkole = 1,NazivSkole = "Information Technology High School", Skraceno = "ITHS"},
                new Models.SkolaModel() { IdSkole = 2, NazivSkole = "Nikola Tesla", Skraceno = "NiTe" },
                new Models.SkolaModel() { IdSkole = 3, NazivSkole = "Mihajlo Pupin", Skraceno = "MihP" }
                );
           
        }
    }
}
