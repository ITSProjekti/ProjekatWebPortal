using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekat.Models
{
    /// <summary>
    /// PredmetModel class
    /// </summary>
    public class PredmetModel
    {
        /// <summary>
        /// Gets or sets the predmet identifier.
        /// </summary>
        /// <value>
        /// The predmet identifier.
        /// </value>
        [Key]
        public int predmetId { get; set; }

        /// <summary>
        /// Gets or sets the predmet name.
        /// </summary>
        /// <value>
        /// The predmet name.
        /// </value>
        public string predmetNaziv { get; set; }

        /// <summary>
        /// Gets or sets the predmet description.
        /// </summary>
        /// <value>s
        /// The predmet description.
        /// </value>
        public string predmetOpis { get; set; }

        public TipPredmetaModel TipPredmetaModel { get; set; }

        /// <summary>
        /// Gets or sets the tip predmeta identifier.
        /// </summary>
        /// <value>
        /// The tip predmeta identifier.
        /// </value>
        [ForeignKey("TipPredmetaModel")]
        public int tipId { get; set; }

        /// <summary>
        ///  Gets or sets the queryable data source for Predmeti.
        /// </summary>
        /// <value>
        /// Queryable selection of PredmetModel Classes.
        /// </value>
        public IEnumerable<PredmetModel> predmeti { get; set; }

        public int? Razred { get; set; } // redni broj razreda gde predmet pripada
    }
}