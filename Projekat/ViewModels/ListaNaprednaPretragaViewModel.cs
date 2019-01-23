using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projekat.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Projekat.ViewModels
{
    /// <summary>
    /// Lista napredna pretraga view model
    /// </summary>
    public class ListaNaprednaPretragaViewModel
    {
        /// <summary>
        /// Gets or sets the korisnici.
        /// </summary>
        /// <value>
        /// The korisnici.
        /// </value>
        public List<ListaKorisnikaViewModel> Korisnici { get; set; }
        /// <summary>
        /// Gets or sets the smerovi.
        /// </summary>
        /// <value>
        /// The smerovi.
        /// </value>
        public IEnumerable<SmerModel> Smerovi { get; set; }
        /// <summary>
        /// Gets or sets the skole.
        /// </summary>
        /// <value>
        /// The skole.
        /// </value>
        public IEnumerable<SkolaModel> Skole { get; set; }
        /// <summary>
        /// Gets or sets the uloge.
        /// </summary>
        /// <value>
        /// The uloge.
        /// </value>
        public IEnumerable<IdentityRole> Uloge { get; set; }

        /// <summary>
        /// Gets or sets the filter skola identifier.
        /// </summary>
        /// <value>
        /// The filter skola identifier.
        /// </value>
        public int FilterSkolaID { get; set; }
        /// <summary>
        /// Gets or sets the filter uloga.
        /// </summary>
        /// <value>
        /// The filter uloga.
        /// </value>
        public string FilterUloga { get; set; }
        /// <summary>
        /// Gets or sets the filter smer identifier.
        /// </summary>
        /// <value>
        /// The filter smer identifier.
        /// </value>
        public int FilterSmerID { get; set; }
    }
}