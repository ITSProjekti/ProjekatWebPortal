using System.Web.Optimization;

namespace Projekat
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // "~/Scripts/jquery.validate*"
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate.min.js"));

            //dodato za upload fajla
            //bundles.Add(new ScriptBundle("~/bundles/js").Include(
            //            "~/Scripts/hamburger.js",
            //            "~/Scripts/VracanjeID.js",
            //            "~/Scripts/loading.js"
            //            ));

            //bundles.Add(new ScriptBundle("~/bundles/jsFile").Include(
            //            "~/Scripts/uploadNaziv.js"
            //            ));
            //bundles.Add(new ScriptBundle("~/bundles/smer").Include(
            //            "~/Scripts/modalOpisSmer.js"
            //            ));

            //bundles.Add(new ScriptBundle("~/bundles/materijal").Include(
            //            "~/Scripts/kontroleRespMaterijaliPrikaz.js",
            //            "~/Scripts/brisanjeMaterijala.js",
            //            "~/Scripts/jquery-ui.min.js"
            //            ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      //"~/Scripts/bootbox.js",
                      "~/Scripts/respond.js"));

            /* OVO SU NOVO DODATI BUNDLOVI */

            bundles.Add(new ScriptBundle("~/bundles/materijal_prikaz").Include(
                       "~/Scripts/Materijal/brisanjeMaterijala.js",
                       "~/Scripts/Materijal/filterMaterijal.js",
                       "~/Scripts/customDropdown.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/upload_materijal").Include(
            "~/Scripts/Materijal/uploadMaterijal.js",
            //"~/Scripts/Materijal/uploadMaterijal.js",
            "~/Scripts/customDropdown.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/DodajModul").Include(
            "~/Scripts/Modul/DodajModul.js",
            //"~/Scripts/Materijal/uploadMaterijal.js",
            "~/Scripts//Modul/customDropdownModul.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/predmet_prikaz").Include(
             "~/Scripts/Predmet/editPredmeta.js",
             "~/Scripts/Predmet/modalOpisPredmet.js",
             "~/Scripts/Predmet/validacijaEditPredmeta.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/novi_predmet").Include(
             "~/Scripts/Predmet/validacijaNovogPredmeta.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/novi_modul").Include(
             "~/Scripts/Modul/validacijaNovogModula.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/edit_modul").Include(
             "~/Scripts/Modul/validacijaEditModula.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/smer_prikaz").Include(
                "~/Scripts/Smer/editSmera.js",
                "~/Scripts/Smer/modalOpisSmer.js",
                "~/Scripts/Smer/validacijaEditSmera.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/novi_smer").Include(
             "~/Scripts/Smer/validacijaNovogSmera.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/novi_korisnik").Include(
             "~/Scripts/Korisnik/register.js",
             "~/Scripts/customDropdown.js",
              "~/Scripts/Korisnik/SakrijGodine.js"

            ));
            bundles.Add(new ScriptBundle("~/bundles/izmeni_korisnika").Include(
           "~/Scripts/customDropdown.js",
           "~/Scripts/Korisnik/izmeniKorisnika.js",
           "~/Scripts/Korisnik/SakrijGodine.js"
           ));

            bundles.Add(new ScriptBundle("~/bundles/lista_korisnika").Include(

             "~/Scripts/datatables.min.js",

             "~/Scripts/Korisnik/listaKorisnika.js",
             "~/Scripts/UI/select2.min.js",
             "~/Scripts/customDropdown.js",

             "~/Scripts/UI/labeli.js"

            ));

            bundles.Add(new ScriptBundle("~/bundles/ui").IncludeDirectory(
                      "~/Scripts/UI", "*.js", true)
                      );
            /*bundles.Add(new ScriptBundle("~/bundles/shared").IncludeDirectory(
                      "~/Scripts/Shared", "*.js", true)
                      );*/
            /* KRAJ NOVIH CISTIH */

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/reset.css",
                      /* "~/Content/bootstrap.css",*/
                      "~/Content/css/bootstrap-flatly.css",
                      "~/Content/css/site.css",
                     "~/Content/css/datatables.min.css",
                      "~/Content/css/izgled.css",
                      "~/Content/css/stil.css",
                      "~/Content/css/simplebar.css",
                      "~/Content/css/detaljiKorisnika.css",
                      "~/Content/css/izmeniKorisnika.css",
                      "~/Content/css/naprednaPretraga.css",
                      "~/Content/css/UrednikOdgovor.css"
                       ));
            bundles.Add(new StyleBundle("~/Content/select2").Include(
                      "~/Content/css/select2.min.css"
                      ));
            bundles.Add(new StyleBundle("~/Content/select2izgled").Include(
                      "~/Content/css/select2izgled.css"
                      ));
        }
    }
}