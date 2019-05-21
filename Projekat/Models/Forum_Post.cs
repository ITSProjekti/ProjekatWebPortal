namespace Projekat.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Forum_Post
    {
        [Key]
        public int Id_Post { get; set; }

        [Required]
        [StringLength(50)]
        public string posttitle { get; set; }

        [Required]
        public string postmessage { get; set; }

        public DateTime posteddate { get; set; }

        [Required]
        [StringLength(10)]
        public string approved { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId_Fk { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
    }
}
