using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekat.Models
{
    public class GlobalniZahteviModel
    {
        [Key]
        public int zahtevId { get; set; }

        public DateTime zahtevDatum { get; set; }
        public string zahtevObrazlozenje { get; set; }

        [ForeignKey("MaterijalModel")]
        public int materijalId { get; set; }

        public MaterijalModel MaterijalModel { get; set; }
    }
}