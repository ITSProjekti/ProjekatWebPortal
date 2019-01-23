using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Projekat.Models
{
    /// <summary>
    /// Telo vesti model
    /// </summary>
    public class TeloVestiModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the vest identifier.
        /// </summary>
        /// <value>
        /// The vest identifier.
        /// </value>
        [ForeignKey("VestModel")]
        public int VestId { get; set; }
        /// <summary>
        /// Gets or sets the vest model.
        /// </summary>
        /// <value>
        /// The vest model.
        /// </value>
        public VestModel VestModel { get; set; }

        /// <summary>
        /// Gets or sets the telo vesti.
        /// </summary>
        /// <value>
        /// The telo vesti.
        /// </value>
        public string TeloVesti { get; set; }
        
    }
}