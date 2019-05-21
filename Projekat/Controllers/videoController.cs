using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projekat.Models;

namespace Projekat.Controllers
{
    public class videoController : Controller
    {

		private VideoContext KONTEKST;
		

        // GET: video
        public ActionResult Index()
        {
            return View(KONTEKST.videoModels.ToList());
        }

		public ActionResult VideoArhiva()
		{
			KONTEKST = new VideoContext();
			ViewBag.tip = "video";
			//return View(KONTEKST.videoModels.Where(pom => pom.Ime.Equals("video")).Single());

			return View(KONTEKST.videoModels.ToList());
		}


		public ActionResult ubaciVideo()
		{
			KONTEKST = new VideoContext();


			return View(KONTEKST.videoModels.ToList());

		}







	}
}