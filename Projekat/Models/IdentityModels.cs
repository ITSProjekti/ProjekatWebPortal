using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace Projekat.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public int? SkolaId { get; set; }
        public int? SmerId { get; set; }
        public string Uloga { get; set; }
        public int? GodinaUpisa { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        [MaxLength]
        public byte[] Slika { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        public static async Task<string> VratiSmer(string username)
        {
            MaterijalContext context = new MaterijalContext();
            ApplicationUser user = await context.Users.FirstOrDefaultAsync(x => x.UserName == username);
            if (user == null)
                return null;
            string smer = (await context.smerovi.FirstOrDefaultAsync(x => x.smerId == user.SmerId))?.smerNaziv;
            return smer;
            
        }
        public static async Task<int?> VratiSmerId(string username)
        {
            MaterijalContext context = new MaterijalContext();
            ApplicationUser user = await context.Users.FirstOrDefaultAsync(x => x.UserName == username);
            if (user == null)
                return null;
           int? smer = (await context.smerovi.FirstOrDefaultAsync(x => x.smerId == user.SmerId))?.smerId;
            return smer;

        }
        public static async Task<int?> vratiSkolu(string username)
        {
            MaterijalContext context = new MaterijalContext();
            ApplicationUser user = await context.Users.FirstOrDefaultAsync(x => x.UserName == username);
            if (user == null)
                return null;
            int? skola = user.SkolaId;
            return skola;
        }
        public static async Task<SkolaModel> vratiSkoluModel(string username)
        {
            MaterijalContext context = new MaterijalContext();
            ApplicationUser user = await context.Users.FirstOrDefaultAsync(x => x.UserName == username);
            if (user == null)
                return null;
            SkolaModel s = await context.Skole.FirstOrDefaultAsync(c => c.IdSkole == user.SkolaId);
            return s;
        }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        
    }
}