using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Projekat.Models
{
    /// <summary>
    /// Agregation class that joins Materijal class and TipMaterijala class
    /// </summary>
    public class MaterijalPoTipu
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
        /// Gets or sets the tip materijala identifier.
        /// </summary>
        /// <value>
        /// The tip materijala identifier.
        /// </value>
        [Key, ForeignKey("TipMaterijalModel"), Column(Order = 1)]
        public int tipMaterijalaId { get; set; }

        /// <summary>
        /// Gets or sets the tip materijal model.
        /// </summary>
        /// <value>
        /// The tip materijal model.
        /// </value>
        public TipMaterijalModel TipMaterijalModel { get; set; }

        /// <summary>
        /// Gets or sets the materijal model.
        /// </summary>
        /// <value>
        /// The materijal model.
        /// </value>
        public MaterijalModel MaterijalModel { get; set; }
    }
}