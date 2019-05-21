namespace Projekat.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class videoModels
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(100)]
        public string Ime { get; set; }

        [StringLength(20)]
        public string Adresa { get; set; }

        [Column(TypeName = "date")]
        public DateTime? datumPostavljanja { get; set; }

        public int? Godina { get; set; }

        [StringLength(30)]
        public string Smer { get; set; }
    }
}
