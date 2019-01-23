using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekat.Models
{
    /// <summary>
    /// Strucna sprema model
    /// </summary>
    public class StrucnaSpremaModel
    {
        /// <summary>
        /// Gets or sets the identifier ss.
        /// </summary>
        /// <value>
        /// The identifier ss.
        /// </value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdSS { get; set; }
        /// <summary>
        /// Gets or sets the naziv ss.
        /// </summary>
        /// <value>
        /// The naziv ss.
        /// </value>
        public string NazivSS { get; set; }
        /// <summary>
        /// Gets or sets the skraceno ss.
        /// </summary>
        /// <value>
        /// The skraceno ss.
        /// </value>
        public string SkracenoSS { get; set; }
    }
}