using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekat.Models
{
    /// <summary>
    /// SmerModel class
    /// </summary>
    public class SmerModel
    {
        /// <summary>
        /// Gets or sets the smer identifier.
        /// </summary>
        /// <value>
        /// The smer identifier.
        /// </value>
        [Key]
        public int smerId { get; set; }

        /// <summary>
        /// Gets or sets the smer name.
        /// </summary>
        /// <value>
        /// The smer name.
        /// </value>
        public string smerNaziv { get; set; }

        /// <summary>
        /// Gets or sets the smer description.
        /// </summary>
        /// <value>
        /// The smer description.
        /// </value>
        public string smerOpis { get; set; }

        /// <summary>
        /// Gets the queryable data source for Smerovi.
        /// </summary>
        /// <value>
        /// Queryable selection of SmerModel Classes.
        /// </value>
        public IEnumerable<SmerModel> smerovi { get; set; }//ovo mozda napravi problem
        public string smerSkraceno { get; set; }
    }
}