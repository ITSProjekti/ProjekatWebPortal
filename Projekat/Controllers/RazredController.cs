using System.Web;
using System.Web.Mvc;

namespace Projekat.Controllers
{
    public class RazredController : Controller
    {
        // GET: Godina
        public ActionResult RazrediPrikaz(string id)
        {
            if (id == null) // ako je smer null
            {
                return RedirectToAction("SmeroviPrikaz", "Smer");
            }
            object smer = HttpUtility.UrlDecode(id);
            return View("RazrediPrikaz", smer);
        }
    }
}