using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projekat.Models;


namespace Projekat.ViewModels
{
    /// <summary>
    /// Predmet po smeru view mdel
    /// </summary>
    public class PredmetPoSmeruViewModel
    {


        /// <summary>
        /// Gets or sets the predmeti.
        /// </summary>
        /// <value>
        /// The predmeti.
        /// </value>
        public List<PredmetModel> predmeti { get; set; }


        /// <summary>
        /// Gets or sets the smerovi.
        /// </summary>
        /// <value>
        /// The smerovi.
        /// </value>
        public List<SmerModel> smerovi { get; set; }

        /// <summary>
        /// Gets or sets the smerovi identifier.
        /// </summary>
        /// <value>
        /// The smerovi identifier.
        /// </value>
        public List<int> smeroviId { get; set; }
        /// <summary>
        /// Gets or sets the smer identifier.
        /// </summary>
        /// <value>
        /// The smer identifier.
        /// </value>
        public int smerId { get; set; }
        /// <summary>
        /// Gets or sets the predmet identifier.
        /// </summary>
        /// <value>
        /// The predmet identifier.
        /// </value>
        public int predmetId { get; set; }
        /// <summary>
        /// Gets or sets the predmet naziv.
        /// </summary>
        /// <value>
        /// The predmet naziv.
        /// </value>
        public string predmetNaziv { get; set; }
        /// <summary>
        /// Gets or sets the predmet opis.
        /// </summary>
        /// <value>
        /// The predmet opis.
        /// </value>
        public string predmetOpis { get; set; }




    }
}