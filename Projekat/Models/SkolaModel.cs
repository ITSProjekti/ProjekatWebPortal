using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekat.Models
{
    /// <summary>
    /// Skola model
    /// </summary>
    public class SkolaModel
    {
        /// <summary>
        /// Gets or sets the identifier skole.
        /// </summary>
        /// <value>
        /// The identifier skole.
        /// </value>
        [Key]
        public int IdSkole { get; set; }
        /// <summary>
        /// Gets or sets the naziv skole.
        /// </summary>
        /// <value>
        /// The naziv skole.
        /// </value>
        public string NazivSkole { get; set; }
        /// <summary>
        /// Gets or sets the skraceno.
        /// </summary>
        /// <value>
        /// The skraceno.
        /// </value>
        public string Skraceno { get; set; }
    }
}