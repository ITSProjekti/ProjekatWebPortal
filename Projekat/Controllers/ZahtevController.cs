using Projekat.Models;
using Projekat.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Projekat.Controllers
{
    public class ZahtevController : Controller
    {
        private IMaterijalContext context;

        public ZahtevController()
        {
            context = new MaterijalContext();
        }

        // GET: Zahtev
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult UpgradeMaterijal(int id, string opis)
        {
            bool result = false;
            context = new MaterijalContext();
            List<GlobalniZahteviModel> zahtevi = context.globalniZahtevi.Where(x => x.materijalId == id).ToList();
            if (zahtevi.Count > 0)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            DateTime date = DateTime.Now;
            GlobalniZahteviModel zahtev = new GlobalniZahteviModel()
            {
                zahtevDatum = date,
                zahtevObrazlozenje = opis,
                materijalId = id
            };
            try
            {
                context.Add<GlobalniZahteviModel>(zahtev);
                context.SaveChanges();
            }
            catch { }
            result = true;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult PrikazZahteva()
        {
            List<GlobalniZahtevViewModel> viewModels = new List<GlobalniZahtevViewModel>();

            List<GlobalniZahteviModel> globalni;

            globalni = context.globalniZahtevi.ToList();

            foreach (var item in globalni)
            {
                GlobalniZahtevViewModel zahtev = new GlobalniZahtevViewModel()
                {
                    materijal = context.materijali.Single(x => x.materijalId == item.materijalId),
                    globalni = item,
                };

                viewModels.Add(zahtev);
            }

            return View(viewModels);
        }

        [HttpPost]
        [Authorize(Roles = "GlobalniUrednik")]
        public JsonResult Delete(int Id)
        {
            bool result = false;
            GlobalniZahteviModel zahtev;
            try
            {
                zahtev = context.globalniZahtevi.Single(x => x.zahtevId == Id);
            }
            catch
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            try
            {
                context.Delete<GlobalniZahteviModel>(zahtev);
                context.SaveChanges();
                result = true;
            }
            catch
            {
                result = false;
                return Json(result, JsonRequestBehavior.AllowGet);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}