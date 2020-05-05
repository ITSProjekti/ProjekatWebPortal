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

        [Authorize(Roles = "GlobalniUrednik,SuperAdministrator")]
        public JsonResult UpgradeMaterijal(int id, string opis)
        {
            context = new MaterijalContext();
            List<GlobalniZahteviModel> zahtevi = context.globalniZahtevi.Where(x => x.materijalId == id).ToList();

            List<MaterijalPoModulu> matPoMod = context.materijalPoModulu.Where(x => x.materijalId == id).ToList();
            List<ModulModel> moduli = new List<ModulModel>();
            bool globalBool = true;
            bool result = false;

            foreach (MaterijalPoModulu item in matPoMod)
            {
                ModulModel temp = context.moduli.Where(x => x.modulId == item.modulId).FirstOrDefault();
                PredmetModel tempPred = context.predmeti.Where(x => x.predmetId == temp.predmetId).FirstOrDefault();

                if (tempPred.tipId == 2)
                {
                    globalBool = false;
                }
            }

            if (zahtevi.Count == 0 && globalBool)
            {
                result = true;
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

                return Json(result, JsonRequestBehavior.AllowGet);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Authorize(Roles = "GlobalniUrednik,SuperAdministrator")]
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
        [Authorize(Roles = "GlobalniUrednik,SuperAdministrator")]
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

        [HttpGet]
        [Authorize(Roles = "GlobalniUrednik,SuperAdministrator")]
        public ActionResult Accept(int id, int? predmetId)
        {
            GlobalniZahtevViewModel viewModel;
            MaterijalModel mat = context.pronadjiMaterijalPoId(id);
            GlobalniZahteviModel global = context.globalniZahtevi.Where(x => x.zahtevId == id).FirstOrDefault();

            if (predmetId == null)
            {
                try
                {
                    List<PredmetModel> predmets = context.predmeti.Where(x => x.tipId == 2).ToList();
                    List<ModulModel> moduls = context.moduli.ToList();
                    List<ModulModel> moduliPoPredmets = moduls.Where(x => x.predmetId == predmets.First().predmetId).ToList();
                    viewModel = new GlobalniZahtevViewModel()
                    {
                        Moduli = moduls,
                        Predmeti = predmets,
                        ModuliPoPredmetu = moduliPoPredmets,
                        predmetId = predmets.First().predmetId,
                        modulId = moduliPoPredmets.First().modulId,
                        materijal = mat,
                        globalni = global
                    };
                    return View(viewModel);
                }
                catch (Exception)
                {
                    return View("HttpNotFound");
                }
            }
            else
            {
                try
                {
                    List<PredmetModel> predmets = context.predmeti.Where(x => x.tipId == 2).ToList();
                    List<ModulModel> moduls = context.moduli.ToList();
                    List<ModulModel> moduliPoPredmets = moduls.Where(x => x.predmetId == predmetId).ToList();
                    viewModel = new GlobalniZahtevViewModel()
                    {
                        Moduli = moduls,
                        Predmeti = predmets,
                        ModuliPoPredmetu = moduliPoPredmets,
                        predmetId = predmets.First().predmetId,
                        modulId = moduliPoPredmets.First().modulId,
                        materijal = mat,
                        globalni = global
                    };
                    return PartialView("_ZahtevDropdown", viewModel);
                }
                catch (Exception)
                {
                    return View("HttpNotFound");
                }
            }
        }

        [HttpPost]
        [Authorize(Roles = "GlobalniUrednik,SuperAdministrator")]
        public ActionResult Accept(GlobalniZahtevViewModel viewmodel)
        {
            MaterijalPoModulu temp = new MaterijalPoModulu()
            {
                modulId = viewmodel.modulId,
                materijalId = viewmodel.globalni.materijalId
            };
            GlobalniZahteviModel gzm = context.globalniZahtevi.Where(x => x.zahtevId == viewmodel.globalni.zahtevId).FirstOrDefault();
            try
            {
                context.Add<MaterijalPoModulu>(temp);
                context.Delete<GlobalniZahteviModel>(gzm);
                context.SaveChanges();
            }
            catch (Exception) { }
            return RedirectToAction("PrikazZahteva");
        }
    }
}