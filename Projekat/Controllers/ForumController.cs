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
        [Authorize(Roles ="Profesor,Ucenik")]
        public ViewResult forum()
        {
            //Beleznik: potrebna inicijalizacija da bi se ucitali podaci na view modele
            //
            ForumContext fx = new ForumContext();

            var model = fx.Forum_Post.ToList();

            var myviewmodel = new ForumViewModel();

            //Pune se modelview modeli tipa IENUMERABLE sa podacima iz contekst modela
            //
            myviewmodel.postsModel=model;

            return View(myviewmodel); 
        }
        public ActionResult PrikaziSadrzaj(int idPost)
        {
            ForumContext fx = new ForumContext();
            var model = fx.Forum_Post.Where(x => x.Id_Post.Equals(idPost)).ToList();
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