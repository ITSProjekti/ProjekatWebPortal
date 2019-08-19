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
            context.Forum.AddOrUpdate(x => x.Id_post,
                new Models.Forum_Post() { posttitle = "Naslov2", postmessage = "blablablatruc", posteddate = DateTime.Now, approved = "true", Id = "00aa0b52-9e48-4981-bbb9-76219edfffba" });
            /*context.Users.AddOrUpdate(x => x.Id,
                new Models.AspNetUser() { Id= "00aa0b52-9e48-4981-bbb9-76219edfffba",Email= "fafwafwa@mail.com",EmailConfirmed=false,PasswordHash= "ABbCIUewtUgNTxE3VPDnIkzBD9RBWpbWyRaclOhkbAHtmCzKBtzzK0CYrBVhPARFfg==",SecurityStamp= "1fa354ed-61e0-4225-983c-5a02fb1d70c6",PhoneNumber= "fawfwaf",PhoneNumberConfirmed=false,TwoFactorEnabled=false,LockoutEndDateUtc=null,LockoutEnabled=true,AccessFailedCount=0,UserName= "Profesor",Ime= "fnaofnoiaf",Prezime= "fafawfawf",Slika=new byte[0x89504E470D0A1A0A0000000D49484452000001F4000001F4080200000044B448DD000000017352474200AECE1CE90000000467414D410000B18F0BFC61050000000970485973000012740000127401DE661F780000103549444154785EEDDAD1721BC7B244D1FBFF3F7D6E48B119362D42C4800360BA7AAD779998AECC7CF2FF],SkolaId=1,GodinaUpisa=null,SmerId=8,Uloga="Profesor" },
            new Models.AspNetUser() { Id = "0eac528f-22c0-444d-9fb7-de43cffdb239", Email = "dawd@daw.com", EmailConfirmed = false, PasswordHash = "ADChpGlzNlNDZGhqtN3dCXfHXftDV+0o/7wMJZXRBTTQ580CmdaNYTluV880GX3THA==", SecurityStamp = "a3efd0de-3341-48fd-8630-c3111938a289", PhoneNumber = "wdawdd", PhoneNumberConfirmed = false, TwoFactorEnabled = false, LockoutEndDateUtc = null, LockoutEnabled = true, AccessFailedCount = 0, UserName = "Urednik", Ime = "fnaofnoiaf", Prezime = "fafawfawf", Slika = Convert.ToByte(0x89504E470D0A1A0A0000000D49484452000001F4000001F4080200000044B448DD000000017352474200AECE1CE90000000467414D410000B18F0BFC61050000000970485973000012740000127401DE661F780000103549444154785EEDDAD1721BC7B244D1FBFF3F7D6E48B119362D42C4800360BA7AAD779998AECC7CF2FF), SkolaId = 1, GodinaUpisa = null, SmerId = 8, Uloga = "Urednik" },
            new Models.AspNetUser() { Id = "40c225fe-a554-4b6b-b25f-9c30b0cbbfb2", Email = "fijafpiwamfoia@fmail.com", EmailConfirmed = false, PasswordHash = "AGeeSHxNORzrKu4QDpJO5PaUXfXj5igateqPrA+4Zecdo9EiH0Tgz0i1rHuNmjvFBw==", SecurityStamp = "114be7e5-7053-4709-95ce-45cfe1570e5f", PhoneNumber = "12323", PhoneNumberConfirmed = false, TwoFactorEnabled = false, LockoutEndDateUtc = null, LockoutEnabled = true, AccessFailedCount = 0, UserName = "Administrator", Ime = "fnaofnoiaf", Prezime = "fafawfawf", Slika = Convert.ToByte(0x89504E470D0A1A0A0000000D49484452000001F4000001F4080200000044B448DD000000017352474200AECE1CE90000000467414D410000B18F0BFC61050000000970485973000012740000127401DE661F780000103549444154785EEDDAD1721BC7B244D1FBFF3F7D6E48B119362D42C4800360BA7AAD779998AECC7CF2FF), SkolaId = 1, GodinaUpisa = null, SmerId = 8, Uloga = "Administrator" },
            new Models.AspNetUser() { Id = "7e621d52-394f-44d6-aaf6-5450bae830da", Email = "ivan.seguljev@yahoo.com", EmailConfirmed = false, PasswordHash = "ADghIDx7h8PC/5tszCPgWCqbWamOXk3JNq+JNmYGVzuNKh0bNhMOimUExvJ1xUlXqg==", SecurityStamp = "32ac5133-cdc7-49cd-9f48-e1e02cb0fe21", PhoneNumber = "12323", PhoneNumberConfirmed = false, TwoFactorEnabled = false, LockoutEndDateUtc = null, LockoutEnabled = true, AccessFailedCount = 0, UserName = "Ucenik", Ime = "fnaofnoiaf", Prezime = "fafawfawf", Slika = Convert.ToByte(0x89504E470D0A1A0A0000000D49484452000001F4000001F4080200000044B448DD000000017352474200AECE1CE90000000467414D410000B18F0BFC61050000000970485973000012740000127401DE661F780000103549444154785EEDDAD1721BC7B244D1FBFF3F7D6E48B119362D42C4800360BA7AAD779998AECC7CF2FF), SkolaId = 1, GodinaUpisa = null, SmerId = 8, Uloga = "Ucenik" },
            new Models.AspNetUser() { Id = "e902beaf-f539-4876-8e12-78bec19a0559", Email = "ivawafw@fafawfaw.com", EmailConfirmed = false, PasswordHash = "ADE3Zyyui75yao0JTCxWZ8FI8/qUSfQ8x3tExZpTxMeunvk0X+C47A/AZFXFuoqBGw==", SecurityStamp = "2d0b94a7-f94e-4270-9382-e87f01f84b5c", PhoneNumber = "12323", PhoneNumberConfirmed = false, TwoFactorEnabled = false, LockoutEndDateUtc = null, LockoutEnabled = true, AccessFailedCount = 0, UserName = "SuperAdministrator", Ime = "fnaofnoiaf", Prezime = "fafawfawf", Slika = Convert.ToByte(0x89504E470D0A1A0A0000000D49484452000001F4000001F4080200000044B448DD000000017352474200AECE1CE90000000467414D410000B18F0BFC61050000000970485973000012740000127401DE661F780000103549444154785EEDDAD1721BC7B244D1FBFF3F7D6E48B119362D42C4800360BA7AAD779998AECC7CF2FF), SkolaId = 1, GodinaUpisa = null, SmerId = 8, Uloga = "SuperAdministrator" });
            */    
        }
    }
}
