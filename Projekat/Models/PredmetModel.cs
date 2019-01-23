using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.ComponentModel;
using System.Web.Mvc;

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

        /// <summary>
        ///  Gets or sets the queryable data source for Predmeti.
        /// </summary>
        /// <value>
        /// Queryable selection of PredmetModel Classes.
        /// </value>
        public IEnumerable<PredmetModel> predmeti { get; set; }
    }
}