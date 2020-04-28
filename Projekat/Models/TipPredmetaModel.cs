using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Projekat.Models
{
    public class TipPredmetaModel
    {
        /// <summary>
        /// Gets or sets the tip predmeta identifier.
        /// </summary>
        /// <value>
        /// The tip predmeta identifier.
        /// </value>
        [Key]
        public int tipId { get; set; }

        /// <summary>
        /// Gets or sets the name of tip predmeta.
        /// </summary>
        /// <value>
        /// The name of tip predmeta.
        /// </value>

        public string tipNaziv { get; set; }

        public IEnumerable<PredmetModel> predmeti { get; set; }
    }
}