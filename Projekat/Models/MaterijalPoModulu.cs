using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekat.Models
{
    public class MaterijalPoModulu
    {
        /// <summary>
        /// Gets or sets the modul identifier.
        /// </summary>
        /// <value>
        /// The modul identifier.
        /// </value>
        [Key, ForeignKey("ModulModel"), Column(Order = 0)]
        public int modulId { get; set; }

        /// <summary>
        /// Gets or sets the materijal identifier.
        /// </summary>
        /// <value>
        /// The materijal identifier.
        /// </value>
        [Key, ForeignKey("MaterijalModel"), Column(Order = 1)]
        public int materijalId { get; set; }

        /// <summary>
        /// Gets or sets the materijal model.
        /// </summary>
        /// <value>
        /// The materijal model.
        /// </value>
        public MaterijalModel MaterijalModel { get; set; }

        /// <summary>
        /// Gets or sets the modul model.
        /// </summary>
        /// <value>
        /// The modul model.
        /// </value>
        public ModulModel ModulModel { get; set; }
    }
}