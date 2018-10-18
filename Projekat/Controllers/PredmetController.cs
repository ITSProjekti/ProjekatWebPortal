using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projekat.Models;
using Projekat.ViewModels;
using MvcSiteMapProvider.Web.Mvc.Filters;

namespace Projekat.Controllers
{
    /// <summary>
    /// Predmet Kontroler
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    [Authorize]
    public class PredmetController : Controller
    {
        private IMaterijalContext context;
        // GET: Predmet
        /// <summary>
        /// Index akcija
        /// </summary>
        /// <returns>IndexView</returns>
        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// Vraca stranicu sa formom za dodavanje predmeta
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "SuperAdministrator,Urednik")]
        public ActionResult DodajPredmet()
        {

            context = new MaterijalContext();
            DodajPremetViewModel viewModel = new DodajPremetViewModel();
            viewModel.smerovi = context.smerovi.ToList();



            return View("DodajPredmet", viewModel);
        }

        /// <summary>
        /// Dodaje predmet u bazu i dodaje smerove na kojima je predmet u tabelu PredmetPoSmeru
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "SuperAdministrator,Urednik")]
        public ActionResult DodajPredmet(DodajPremetViewModel viewModel)
        {

            context = new MaterijalContext();



            try
            {
                context.Add<PredmetModel>(viewModel.predmet);

                foreach (int n in viewModel.smerIds)
                {

                    context.Add<PredmetPoSmeru>(new PredmetPoSmeru
                    {
                        predmetId = viewModel.predmet.predmetId,
                        smerId = n
                        //smerId = viewModel.smer.smerId
                    });
                }

                context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("DodajPredmet", "Predmet");
        }

        /// <summary>
        /// Menja Predmet u bazi
        /// </summary>
        /// <param name="smerId">The smer identifier.</param>
        /// <param name="smeroviId">Lista smerova na kojima je predmet.</param>
        /// <param name="predmetNaziv">Novi naziv predmeta.</param>
        /// <param name="predmetOpis">Novi opis predmeta.</param>
        /// <param name="predmetId">Id predmeta koji treba promeniti.</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "SuperAdministrator,Urednik")]
        public ActionResult Edit(int smerId, List<int> smeroviId, string predmetNaziv, string predmetOpis, int predmetId)
        {
            context = new MaterijalContext();

            PredmetModel predmetPromenjenji = context.predmeti.FirstOrDefault(m => m.predmetId == predmetId);
            List<int> smeroviIdIzBaze = context.predmetiPoSmeru.Where(m => m.predmetId == predmetId).Select(m => m.smerId).ToList();

            if (predmetPromenjenji == null)
            {
                return new HttpNotFoundResult("Nije nadjen ni jedan predmet u bazi sa datim ID-om");
            }
            predmetPromenjenji.predmetNaziv = predmetNaziv;
            predmetPromenjenji.predmetOpis = predmetOpis;

            foreach (int smerID in smeroviId)
            {
                if (!smeroviIdIzBaze.Contains(smerID))
                {
                    context.Add<PredmetPoSmeru>(new PredmetPoSmeru
                    {

                        predmetId = predmetId,
                        smerId = smerID

                    });
                }
            }
            foreach (int smerID in smeroviIdIzBaze)
            {
                if (!smeroviId.Contains(smerID))
                {


                    List<PredmetPoSmeru> lista = context.predmetiPoSmeru.Where(m => m.predmetId == predmetId).ToList();
                    foreach (PredmetPoSmeru predmet in lista)
                    {
                        context.Delete(predmet);
                    }
                }



            }

            foreach (int smerID in smeroviIdIzBaze)
            {
                if (!smeroviId.Contains(smerID))
                {
                    List<PredmetPoSmeru> lista = context.predmetiPoSmeru.Where(m => m.predmetId == predmetId).ToList();
                    foreach (PredmetPoSmeru predmetPoSmeru in lista)
                    {
                        context.Delete(predmetPoSmeru);
                    }
                }

            }


            context.SaveChanges();

            string smernaziv = context.smerovi.FirstOrDefault(x => x.smerId == smerId).smerNaziv;



            return RedirectToAction("PredmetiPrikaz", new { smer = smernaziv });

        }

        /// <summary>
        /// Vratis the smerove.
        /// </summary>
        /// <param name="id">Id predmeta.</param>
        /// <returns>Json sa smerovima</returns>
        [HttpGet]
        public ActionResult VratiSmerove(int id)
        {
            context = new MaterijalContext();

            List<int> smeroviId= context.predmetiPoSmeru.Where(m => m.predmetId == id).Select(m => m.smerId).ToList();

            List<int> smeroviModel = new List<int>();

            foreach (int smerId in smeroviId)
            {
                int smer = context.smerovi.Where(m => m.smerId == smerId).Select(m=>m.smerId).Single();
                smeroviModel.Add(smer);
            }

            return Json(smeroviModel, JsonRequestBehavior.AllowGet);

        }


        //GET: /Predmet/PredmetiPrikaz
        /// <summary>
        /// Prikazuje predmete na odredjenom smeru
        /// </summary>
        /// <param name="Smer">Naziv smera za koji zelimo da prikazemo predmete.</param>
        /// <returns></returns>
        [HttpGet]
        
        public ActionResult PredmetiPrikaz(string Smer)
        {

            int id;
            context = new MaterijalContext();
            try
            {
                id = context.smerovi.FirstOrDefault(x => x.smerNaziv == Smer).smerId;
            }
            catch
            {

                return View("FileNotFound"); ;
            }
            
            List<PredmetPoSmeru> poSmeru = context.predmetiPoSmeru.Where(m => m.smerId == id).ToList();
            List<PredmetModel> model = new List<PredmetModel>();
            List<PredmetModel> tempPredmet = context.predmeti.ToList();
            List<SmerModel> smerovi = context.smerovi.ToList();

            foreach (PredmetPoSmeru ps in poSmeru)
            {
                model.Add(tempPredmet.Where(m => m.predmetId == ps.predmetId).Single());
            }



            PredmetPoSmeruViewModel predmetiPoSmeru = new PredmetPoSmeruViewModel
            {
                predmeti = model,
                smerovi = smerovi,
                smerId = id

            };

            //try
            //{

            //}
            //catch (Exception)
            //{

            //    throw;
            //}

            return View("PredmetiPrikaz", predmetiPoSmeru);
        }



    }
}