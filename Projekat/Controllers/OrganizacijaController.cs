using Projekat.Models;
using Projekat.ViewModels;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projekat.Controllers
{
    public class OrganizacijaController : Controller
    {
        private MaterijalContext materijal;

        public OrganizacijaController()
        {
            materijal = new MaterijalContext();
        }

        // GET: Organizacija
        [Authorize(Roles = "LokalniUrednik,Profesor,Ucenik,SuperAdministrator")]
        public ViewResult kalendarNastave()
        {
            return View();
        }

        [Authorize(Roles = "LokalniUrednik,Profesor,Ucenik,SuperAdministrator,Administrator")]
        [HttpGet]
        public ViewResult planNastave()
        {
            List<SmerModel> model = materijal.smerovi.ToList();
            if (model.Count() > 0)
            {
                var myviewmodel = new SmerViewModel();

                myviewmodel.smerovi = model;

                return View(myviewmodel);
            }
            else
            {
                ViewBag.Poruka = "Trenutno nema nikakvih smerova!";
                return View();
            }
        }

        [HttpGet]
        [Authorize(Roles = "LokalniUrednik")]
        public ActionResult dodavanjeNastave()
        {
            List<SmerModel> model = materijal.smerovi.ToList();
            if (TempData["SuccMsg"] != null) { ViewBag.SuccMsg = TempData["SuccMsg"]; }

            if (model.Count > 0)
            {
                var myviewmodel = new SmerViewModel();
                myviewmodel.smerovi = model;

                return View(myviewmodel);
            }
            else
            {
                return new HttpNotFoundResult("Nešto nije u redu!");
            }
        }

        [HttpPost]
        [Authorize(Roles = "LokalniUrednik")]
        public ActionResult UploadPlan(string tip, HttpPostedFileBase file, SmerViewModel model)
        {
            int smerId = model.smeroviModel.smerId;
            SmerModel modelsmer = materijal.smerovi.Find(smerId);

            if (tip.Equals("its"))
            {
                using (MaterijalContext db = new MaterijalContext())
                {
                    db.smerovi.Attach(modelsmer);

                    modelsmer.fajlIts = new byte[file.ContentLength];
                    file.InputStream.Read(modelsmer.fajlIts, 0, file.ContentLength);
                    modelsmer.fileMimeTypeIts = file.ContentType;
                    modelsmer.nazivFajlIts = Path.GetFileName(file.FileName);

                    db.SaveChanges();
                }
                TempData["SuccMsg"] = "Uspešno dodat plan nastave";
                return RedirectToAction("dodavanjeNastave", "Organizacija");
            }
            else if (tip.Equals("ns"))
            {
                using (MaterijalContext db = new MaterijalContext())
                {
                    db.smerovi.Attach(modelsmer);

                    modelsmer.fajlNs = new byte[file.ContentLength];
                    file.InputStream.Read(modelsmer.fajlNs, 0, file.ContentLength);
                    modelsmer.fileMimeTypeNs = file.ContentType;
                    modelsmer.nazivFajlNs = Path.GetFileName(file.FileName);

                    db.SaveChanges();
                }
                TempData["SuccMsg"] = "Uspešno dodat plan nastave";
                return RedirectToAction("dodavanjeNastave", "Organizacija");
            }
            else if (tip.Equals("ms"))
            {
                using (MaterijalContext db = new MaterijalContext())
                {
                    db.smerovi.Attach(modelsmer);

                    modelsmer.fajlMs = new byte[file.ContentLength];
                    file.InputStream.Read(modelsmer.fajlMs, 0, file.ContentLength);
                    modelsmer.fileMimeTypeMs = file.ContentType;
                    modelsmer.nazivFajlMs = Path.GetFileName(file.FileName);

                    db.SaveChanges();
                }

                TempData["SuccMsg"] = "Uspešno dodat plan nastave";
                return RedirectToAction("dodavanjeNastave", "Organizacija");
            }
            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult SkidanjePlana(int id, string type)
        {
            SmerModel model = materijal.smerovi.Find(id);
            if (type.Equals("iths"))
            {
                return File(model.fajlIts, model.fileMimeTypeIts, model.nazivFajlIts);
            }
            else if (type.Equals("ns"))
            {
                return File(model.fajlNs, model.fileMimeTypeNs, model.nazivFajlNs);
            }
            else if (type.Equals("ms"))
            {
                return File(model.fajlMs, model.fileMimeTypeMs, model.nazivFajlMs);
            }
            return HttpNotFound();
        }

        [Authorize(Roles = "LokalniUrednik,Profesor,Ucenik,SuperAdministrator")]
        public ViewResult rasporedCasova()
        {
            return View();
        }
    }
}