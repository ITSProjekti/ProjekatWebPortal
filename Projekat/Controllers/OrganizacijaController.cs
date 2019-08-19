using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projekat.Controllers
{
    public class OrganizacijaController : Controller
    {
        // GET: Organizacija
        [Authorize(Roles ="Urednik,Profesor,Ucenik,SuperAdministrator")]
        public ViewResult kalendarNastave()
        {
            return View();
        }
        [Authorize(Roles ="Urednik,Profesor,Ucenik,SuperAdministrator")]
        public ViewResult planNastave() {
            return View();
        }
        [Authorize(Roles = "Urednik,Profesor,Ucenik,SuperAdministrator")]
        public ViewResult rasporedCasova() {
            return View();
        }
    }
}