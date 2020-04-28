using Projekat.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Projekat.Controllers
{
    /// <summary>
    /// Smer Kontroler
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    [Authorize]
    public class SmerController : Controller
    {
        private IMaterijalContext context;

        /// <summary>
        /// Kreira novu instancu <see cref="SmerController" /> klase.
        /// </summary>
        public SmerController()
        {
            context = new MaterijalContext();
        }

        /// <summary>
        /// Kreira novu instancu <see cref="SmerController"/> klase.
        /// </summary>
        /// <param name="Context">ImaterijalContext.</param>
        public SmerController(IMaterijalContext Context)
        {
            context = Context;
        }

        // GET: Smer
        /// <summary>
        /// Index akcija
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Vraca prikaz svih smerova.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> SmeroviPrikaz()
        {
            if (this.User.IsInRole("Ucenik"))
            {
                string SmerNaziv = await ApplicationUser.VratiSmer(User.Identity.Name);
                if (SmerNaziv != null)
                    return Redirect("/Razred/RazrediPrikaz/" + Url.Encode(SmerNaziv));
                else
                    return new HttpNotFoundResult("Smer nije nadjen");
            }
            List<SmerModel> smeroviInDb;
            smeroviInDb = context.smerovi.ToList();
            SmerModel smer = new SmerModel();
            smer.smerovi = smeroviInDb;

            return View("SmeroviPrikaz", smer);
        }

        /// <summary>
        /// Vraca View na kome je forma za dodavanje smera
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "SuperAdministrator,LokalniUrednik")]
        public ActionResult DodajSmer()
        {
            return View();
        }

        /// <summary>
        /// Dodaje prosledjeni smer u bazu ili menja postojeci smer u bazi
        /// </summary>
        /// <param name="smer">Smer za dodavanje</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "SuperAdministrator,LokalniUrednik")]
        public ActionResult DodajSmer(SmerModel smer)
        {
            if (ModelState.IsValid)
            {
                if (smer.smerId == 0)
                {
                    context.Add<SmerModel>(smer);
                    context.SaveChanges();
                }
                else
                {
                    var smerInDb = context.smerovi.Single(o => o.smerId == smer.smerId);

                    smerInDb.smerNaziv = smer.smerNaziv;
                    smerInDb.smerOpis = smer.smerOpis;

                    context.SaveChanges();
                }

                return RedirectToAction("SmeroviPrikaz");
            }
            return View();
        }
    }
}