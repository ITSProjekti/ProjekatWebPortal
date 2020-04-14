using Projekat.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Projekat.Controllers
{
    public class ModulController : Controller
    {
        private IMaterijalContext context;

        // GET: Modul
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ModulPrikaz(int id)
        {
            context = new MaterijalContext();
            int pID;
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
    }
}