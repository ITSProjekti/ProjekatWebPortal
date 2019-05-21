using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projekat.Models;

namespace Projekat.Controllers
{

	public class OrganizacijaController : Controller
	{
		private AspNetOrganizacijaContext KONTEKST;
		// GET: Organizacija

		public ActionResult kalendarNastave()
		{
			KONTEKST = new AspNetOrganizacijaContext();
			ViewBag.Tip = "kalendar";
			return View(KONTEKST.AspNetOrganizacijaModels.Where(pom => pom.Ime.Equals("kalendar")).Single());

		}
		public ActionResult planNastave()
		{
			KONTEKST = new AspNetOrganizacijaContext();
			ViewBag.Tip = "plan";
			return View(KONTEKST.AspNetOrganizacijaModels.Where(pom => pom.Ime.Equals("plan")).Single());
		}
		public ActionResult rasporedCasova()
		{
			KONTEKST = new AspNetOrganizacijaContext();
			ViewBag.Tip = "raspored";
			return View(KONTEKST.AspNetOrganizacijaModels.Where(pom => pom.Ime.Equals("raspored")).Single());
		}


		[HttpPost]
		public ActionResult uploadOrganizacijaMaterijal(HttpPostedFileBase file, string tip)
		{
			var fileName = "";
			
			if (file != null && file.ContentLength > 0)
			{
				fileName = Path.GetFileName(file.FileName);

				var path = Path.Combine(Server.MapPath("~/Content/organizacija"), fileName);
				file.SaveAs(path);

			}


			using (KONTEKST = new AspNetOrganizacijaContext())
			{
				var red = KONTEKST.AspNetOrganizacijaModels.Where(b => b.Ime.Equals(tip)).Single();

				if (red != null)
				{
					red.Adresa = "../../Content/organizacija/" + fileName;
					KONTEKST.SaveChanges();
				}

			}

			
			string returnPom = "";

			switch (tip)
			{
				case "raspored":
					returnPom = "rasporedCasova";
					break;

				case "plan":
					returnPom = "planNastave";
					break;

				case "kalendar":
					returnPom = "kalendarNastave";
					break;


			}


			return RedirectToAction(returnPom, "Organizacija");



		}



		[HttpPost]
		public ActionResult downloadOrganizacijaMaterijal(HttpPostedFileBase file, string tip)
		{
			string outputPom;
			using (KONTEKST = new AspNetOrganizacijaContext())
			{
				var imeFajla = KONTEKST.AspNetOrganizacijaModels.Where(red => red.Ime.Equals(tip)).Select(a => a.Adresa).Single();

				outputPom = imeFajla.ToString().Replace("../../Content/organizacija/", "");
			}


			
			byte[] fileBytes = System.IO.File.ReadAllBytes(Path.Combine(Server.MapPath("~/Content/organizacija"), outputPom));
			string fileName = outputPom;
			return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
			
		}
	}

}