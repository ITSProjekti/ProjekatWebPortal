using Projekat.Models;
using System;
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
    }
}