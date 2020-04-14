using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projekat.Models;

namespace Projekat.ViewModels
{
    public class DodajModulViewModel
    {
        /// <summary>
        /// Gets or sets the smerovi.
        /// </summary>
        /// <value>
        /// The smerovi.
        /// </value>
        public IEnumerable<ModulModel> moduli { get; set; } //Za citanje

        /// <summary>
        /// Gets or sets the predmet.
        /// </summary>
        /// <value>
        /// The predmet.
        /// </value>
        public ModulModel modul { get; set; }

        /// <summary>
        /// Gets or sets the smer ids.
        /// </summary>
        /// <value>
        /// The smer ids.
        /// </value>
        public List<int> modulIds { get; set; } //Za upisivanje u bazu

        public IEnumerable<SmerModel> Smerovi { get; set; }

        /// <summary>
        /// Gets or sets the predmet po smeru.
        /// </summary>
        /// <value>
        /// The predmet po smeru.
        /// </value>
        public IEnumerable<PredmetModel> PredmetPoSmeru { get; set; }

        public IEnumerable<PredmetModel> Predmeti { get; set; }
        public int smerId { get; set; }

        /// <summary>
        /// Gets or sets the predmet identifier.
        /// </summary>
        /// <value>
        /// The predmet identifier.
        /// </value>
        public int predmetId { get; set; }
    }
}