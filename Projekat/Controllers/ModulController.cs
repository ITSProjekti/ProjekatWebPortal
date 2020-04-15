using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projekat.Models;
using Projekat.ViewModels;
using System.Data.Entity;
using System.Web.Helpers;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Net;
using System;
using System.Collections.Generic;

namespace Projekat.Controllers
{
    public class ModulController : Controller
    {
        private IMaterijalContext context;

        public ModulController()
        {
            context = new MaterijalContext();
        }

        // GET: Modul
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdministrator,Urednik")]
        public ActionResult DodajModul(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ModulModel m = new ModulModel();
            ViewModels.DodajModulViewModel mm = new DodajModulViewModel();

            m.predmetId = id;

            DodajModulViewModel viewModel = new DodajModulViewModel
            {
                Predmeti = context.predmeti.ToList(),
                Smerovi = context.smerovi.ToList()
            };

            try
            {
                var smerId = viewModel.Smerovi.ToList()[0].smerId;

                var predmetiposmeru = context.predmetiPoSmeru.Where(x => x.smerId == smerId).Select(c => c.predmetId).ToList();
                viewModel.PredmetPoSmeru = (viewModel.Predmeti.Where(x => predmetiposmeru.Contains(x.predmetId)));

                if (TempData["SuccMsg"] != null) { ViewBag.SuccMsg = TempData["SuccMsg"]; }
                //else if (TempData["ErrorMsg"] != null) { ViewBag.ErrorMsg = TempData["ErrorMsg"]; }

                return View("DodajModul", viewModel);
            }
            catch (ArgumentOutOfRangeException)
            {
                return new HttpNotFoundResult("Nema unetih smerova");
            }
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdministrator,Urednik")]
        public ActionResult DodajModul(ViewModels.DodajModulViewModel m)
        {
            context = new MaterijalContext();
            m.modul.predmetId = m.predmetId;
            try
            {
                context.Add<ModulModel>(m.modul);

                context.SaveChanges();
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return RedirectToAction("DodajModul");
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdministrator,Urednik")]
        public ActionResult Delete(int id)
        {
            context = new MaterijalContext();
            var modul = context.moduli.Single(x => x.modulId == id);
            try
            {
                context.Delete(modul);
                context.SaveChanges();
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return RedirectToAction("ModulPrikaz");
        }
    }
}