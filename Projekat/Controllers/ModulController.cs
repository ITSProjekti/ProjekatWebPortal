using Projekat.Models;
using Projekat.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Projekat.Controllers
{
    public class ModulController : Controller
    {
        private IMaterijalContext context;

        public ModulController()
        {
            context = new MaterijalContext();
        }

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        //GET: /Modul/ModulPrikaz
        /// <returns></returns>
        /// </summary>
        /// Prikazuje module na odredjenom predmetu
        /// <param name="id">ID predmeta za koji zelimo da prikazemo module.</param>
        public ActionResult ModulPrikaz(int id)
        {
            context = new MaterijalContext();
            int pID = 0;

            List<ModulModel> modeli;
            try
            {
                pID = context.predmeti.FirstOrDefault(x => x.predmetId == id).predmetId;
            }
            catch { return View("FileNotFound"); }

            if (pID != 0)
            {
                try
                {
                    modeli = context.moduli.Where(x => x.predmetId == pID).ToList();
                }
                catch { return new HttpStatusCodeResult(403); }
                return View(modeli);
            }
            return View("FileNotFound");
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdministrator,Urednik")]
        public ActionResult DodajModul(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewModels.DodajModulViewModel mm = new DodajModulViewModel();
            ModulModel m = new ModulModel();
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
            {
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
}