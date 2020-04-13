using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekat.Models
{
    public class ModulModel
    {
        [Key]
        public int modulId { get; set; }

        [MaxLength(50)]
        public string modulNaziv { get; set; }

        [MaxLength(250)]
        public string modulOpis { get; set; }

        public PredmetModel PredmetModel { get; set; }

        [ForeignKey("PredmetModel")]
        public int? predmetId { get; set; }
    }
}