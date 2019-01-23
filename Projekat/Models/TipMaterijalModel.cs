using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekat.Models
{
    /// <summary>
    /// TipMaterijalaModel class
    /// </summary>
    public class TipMaterijalModel
    {
        /// <summary>
        /// Gets or sets the tip materijal identifier.
        /// </summary>
        /// <value>
        /// The tip materijal identifier.
        /// </value>
        [Key]
        public int tipMaterijalId { get; set; }
        /// <summary>
        /// Gets or sets the name of tip materijala.
        /// </summary>
        /// <value>
        /// The name of tip materijala.
        /// </value>
        public string nazivTipMaterijal { get; set; }
        

    }
}