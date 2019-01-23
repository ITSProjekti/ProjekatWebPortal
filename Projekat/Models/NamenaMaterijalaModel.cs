using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Web.Mvc;

namespace Projekat.Models
{
    /// <summary>
    /// NamenaMaterijala model class
    /// </summary>
    public class NamenaMaterijalaModel
    {
        /// <summary>
        /// Gets or sets the identifier of namena materijala.
        /// </summary>
        /// <value>
        /// The namena materijala identifier.
        /// </value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int namenaMaterijalaId { get; set; }

        /// <summary>
        /// Gets or sets the name of namena materijala.
        /// </summary>
        /// <value>
        /// The namena materijala name.
        /// </value>
        public string namenaMaterijalaNaziv { get; set; }

    }
}