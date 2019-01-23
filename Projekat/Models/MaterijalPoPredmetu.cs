using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Projekat.Models
{
    /// <summary>
    /// Agregation class that joins materijal class with predmet class
    /// </summary>
    public class MaterijalPoPredmetu
    {
        /// <summary>
        /// Gets or sets the materijal identifier.
        /// </summary>
        /// <value>
        /// The materijal identifier.
        /// </value>
        [Key, ForeignKey("MaterijalModel"), Column(Order = 0)]
        public int materijalId { get; set; }


        /// <summary>
        /// Gets or sets the predmet identifier.
        /// </summary>
        /// <value>
        /// The predmet identifier.
        /// </value>
        [Key, ForeignKey("PredmetModel"), Column(Order = 1)]
        public int predmetId { get; set; }

        /// <summary>
        /// Gets or sets the materijal model.
        /// </summary>
        /// <value>
        /// The materijal model.
        /// </value>
        public MaterijalModel MaterijalModel { get; set; }

        /// <summary>
        /// Gets or sets the predmet model.
        /// </summary>
        /// <value>
        /// The predmet model.
        /// </value>
        public PredmetModel PredmetModel { get; set; }
    }
}