using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projekat.Models;

namespace Projekat.ViewModels
{
    /// <summary>
    /// materijal upload view model
    /// </summary>
    public class MaterijalUploadViewModel
    {

        /// <summary>
        /// Gets or sets the materijal.
        /// </summary>
        /// <value>
        /// The materijal.
        /// </value>
        public MaterijalModel  Materijal { get; set; }
        /// <summary>
        /// Gets or sets the predmeti.
        /// </summary>
        /// <value>
        /// The predmeti.
        /// </value>
        public IEnumerable<PredmetModel> Predmeti { get; set; }

        /// <summary>
        /// Gets or sets the tipovi materijala.
        /// </summary>
        /// <value>
        /// The tipovi materijala.
        /// </value>
        public IEnumerable<TipMaterijalModel> tipoviMaterijala { get; set; }

        /// <summary>
        /// Gets or sets the namene materijala.
        /// </summary>
        /// <value>
        /// The namene materijala.
        /// </value>
        public IEnumerable<NamenaMaterijalaModel> nameneMaterijala { get; set; }

        /// <summary>
        /// Gets or sets the smerovi.
        /// </summary>
        /// <value>
        /// The smerovi.
        /// </value>
        public IEnumerable<SmerModel> Smerovi { get; set; }

        /// <summary>
        /// Gets or sets the predmet po smeru.
        /// </summary>
        /// <value>
        /// The predmet po smeru.
        /// </value>
        public IEnumerable<PredmetModel> PredmetPoSmeru { get; set; }
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


    }
}