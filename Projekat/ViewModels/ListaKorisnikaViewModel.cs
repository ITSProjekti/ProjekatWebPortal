using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Projekat.Models;

namespace Projekat.ViewModels
{
    /// <summary>
    /// lista korisnika view model
    /// </summary>
    public class ListaKorisnikaViewModel
    {

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName { get; set; }
        /// <summary>
        /// Gets or sets the prezime.
        /// </summary>
        /// <value>
        /// The prezime.
        /// </value>
        public string Prezime { get; set; }
        /// <summary>
        /// Gets or sets the broj telefona.
        /// </summary>
        /// <value>
        /// The broj telefona.
        /// </value>
        public string Uloga { get; set; }
        /// <summary>
        /// Gets or sets the smer.
        /// </summary>
        /// <value>
        /// The smer.
        /// </value>
        public string Smer { get; set; }
        /// <summary>
        /// Gets or sets the skola.
        /// </summary>
        /// <value>
        /// The skola.
        /// </value>
        public string Skola { get; set; }
    }
}