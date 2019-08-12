using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Projekat.Models
{
    [Table("Forum_Posts")]
    public class Forum_Post
    {
        [Key]
        public int Id_post { get; set; }

        [Required]
        [StringLength(50)]
        public string posttitle { get; set; }

        [Required]
        public string postmessage { get; set; }

        public DateTime posteddate { get; set; }

        [Required]
        [StringLength(10)]
        public string approved { get; set; }

        public AspNetUser aspNetUser { get; set; }

        [Required]
        [StringLength(128)]
        [ForeignKey("aspNetUser")]
        public string Id { get; set; }

    }
}
