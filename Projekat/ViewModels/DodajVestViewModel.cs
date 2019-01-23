using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekat.ViewModels
{
    /// <summary>
    /// Dodaj vest view model
    /// </summary>
    public class DodajVestViewModel
    {
        /// <summary>
        /// Gets or sets the naslov.
        /// </summary>
        /// <value>
        /// The naslov.
        /// </value>
        public string Naslov { get; set; }
        /// <summary>
        /// Gets or sets the vest.
        /// </summary>
        /// <value>
        /// The vest.
        /// </value>
        public string Vest { get; set; }
        /// <summary>
        /// Gets or sets the kratak opis.
        /// </summary>
        /// <value>
        /// The kratak opis.
        /// </value>
        public string KratakOpis { get; set; }

    }
}