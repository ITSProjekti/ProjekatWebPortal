using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Projekat
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
             name: "PrikaziVest",
             url: "Vesti/PrikaziVest/{Naslov}/{Datum}",
             defaults: new { controller = "Vesti", action = "PrikaziVest" }
         );
            routes.MapRoute(
              name: "PredmetiPrikaz",
              url: "Predmet/PredmetiPrikaz/{smer}",
              defaults: new { controller = "Predmet", action = "PredmetiPrikaz" }
          );
            routes.MapRoute(
                name: "DetaljiKorisnika",
                url: "Account/DetaljiKorisnika/{Username}",
                defaults: new { controller = "Account", action = "DetaljiKorisnika" }
            );
            routes.MapRoute(
            name: "MaterijaliZaUcenike",
            url: "Materijali/ZaUcenike/{id}",
            defaults: new { controller = "Materijal", action = "MaterijaliPrikaz" }
        );
            routes.MapRoute(
              name: "MaterijaliZaProf",
              url: "Materijali/ZaProfesore",
              defaults: new { controller = "Materijal", action = "MaterijaliPrikaz" }
          );
          

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }    
            );
            
        }
    }
}
