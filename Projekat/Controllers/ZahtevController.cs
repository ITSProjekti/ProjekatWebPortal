using Projekat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Projekat.Models;
using Projekat.ViewModels;

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

        public JsonResult UpgradeMaterijal(int id)
        {
            DateTime date = DateTime.Now;

            GlobalniZahteviModel zahtev = new GlobalniZahteviModel()
            {
                zahtevDatum = date,
                zahtevObrazlozenje = "",
                materijalId = id
            };

            try
            {
                context.Add<GlobalniZahteviModel>(zahtev);
                context.SaveChanges();
            }
            catch { }

            return Json(true, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult PrikazZahteva()
        {
            List<GlobalniZahtevViewModel> viewModels = new List<GlobalniZahtevViewModel>();

            List<GlobalniZahteviModel> globalni;

            globalni = context.globalniZahtevi.ToList();
            
            foreach(var item in globalni)
            {
                GlobalniZahtevViewModel zahtev = new GlobalniZahtevViewModel()
                {
                    materijal = context.materijali.Single(x=> x.materijalId == item.materijalId),
                    globalni = item,
                };

                viewModels.Add(zahtev);
            }

            return View(viewModels);
        }
    }
}