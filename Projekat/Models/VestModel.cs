using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekat.Models
{
    /// <summary>
    /// Vest model
    /// </summary>
    public class VestModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VestModel"/> class.
        /// </summary>
        public VestModel()
        {
            DatumPostavljanja = DateTime.Now;
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the naslov.
        /// </summary>
        /// <value>
        /// The naslov.
        /// </value>
        public string Naslov { get; set; }
        /// <summary>
        /// Gets or sets the thumbnail.
        /// </summary>
        /// <value>
        /// The thumbnail.
        /// </value>
        public string Thumbnail { get; set; }

        /// <summary>
        /// Gets or sets the kratak opis.
        /// </summary>
        /// <value>
        /// The kratak opis.
        /// </value>
        public string KratakOpis { get; set; }
        /// <summary>
        /// Gets or sets the datum postavljanja.
        /// </summary>
        /// <value>
        /// The datum postavljanja.
        /// </value>
        public DateTime DatumPostavljanja { get; set; }
    }
}