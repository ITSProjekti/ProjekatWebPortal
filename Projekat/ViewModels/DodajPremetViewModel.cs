using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projekat.Models;

namespace Projekat.ViewModels
{
    /// <summary>
    /// Dodaj predmet view model
    /// </summary>
    public class DodajPremetViewModel
    {
        /// <summary>
        /// Gets or sets the smerovi.
        /// </summary>
        /// <value>
        /// The smerovi.
        /// </value>
        public IEnumerable<SmerModel> smerovi { get; set; } //Za citanje
        /// <summary>
        /// Gets or sets the predmet.
        /// </summary>
        /// <value>
        /// The predmet.
        /// </value>
        public PredmetModel predmet { get; set; }

        /// <summary>
        /// Gets or sets the materijalTipId.
        /// </summary>
        /// <value>
        /// The predmet.
        /// </value>
        public TipPredmetaModel tipPred { get; set; }
        public TipPredmetaModel tipId { get; set; }

        /// <summary>
        /// Gets or sets the tipovi.
        /// </summary>
        /// <value>
        /// The predmet.
        /// </value>
        public IEnumerable<TipPredmetaModel> tipoviPredmeta { get; set; } //Za citanje

        /// <summary>
        /// Gets or sets the smer ids.
        /// </summary>
        /// <value>
        /// The smer ids.
        /// </value>
        public List<int> smerIds { get; set; } //Za upisivanje u bazu
        public List<int> tipIds { get; set; } //Za upisivanje u bazu

        public int tip { get; set; }
    }
}