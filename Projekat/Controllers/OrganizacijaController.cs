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
        public ViewResult kalendarNastave()
        {
            return View();
        }
    }
}