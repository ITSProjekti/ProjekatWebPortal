using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projekat.Models;
using Projekat.ViewModels;

namespace Projekat.Controllers
{
    public class ForumController : Controller
    {
        // GET: Forum
        MaterijalContext materijal;

        public ForumController()
        {
            materijal = new MaterijalContext();
        }

        [Authorize(Roles = "Profesor,Ucenik")]
        public ActionResult forum()
        {
            //Beleznik: potrebna inicijalizacija da bi se ucitali podaci na view modele
            //
            List<Forum_Post> model = materijal.Forum.Where(n => n.approved.Equals("yes")).ToList();
            if (model.Count() > 0)
            {
                var myviewmodel = new ForumViewModel();
                myviewmodel.postsModel = model;
                int i = model.Count();
                ViewBag.BrojRezultat = i;
                return View(myviewmodel);
            }
            else
            {
                ViewBag.Poruka = "Trenutno nema nikakvih objava!";
                return View();
            }
        }
        public ActionResult PrikaziSadrzaj(int idPost)
        {
            var model = materijal.Forum.Where(x => x.Id_post.Equals(idPost)).ToList();
            var myviewmodel = new ForumViewModel();

            myviewmodel.postsModel = model;

            return View(myviewmodel);
        }
        public ActionResult Prikaz()
        {
            return View("Sadrzaj");
        }
    }
}