using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Projekat.Models
{
    public class VestiContext:ApplicationDbContext
    {
        /// <summary>
        /// Gets or sets the vesti.
        /// </summary>
        /// <value>
        /// The vesti.
        /// </value>
        public DbSet<VestModel> Vesti { get; set; }
        /// <summary>
        /// Gets or sets the tela vesti.
        /// </summary>
        /// <value>
        /// The tela vesti.
        /// </value>
        public DbSet<TeloVestiModel> TelaVesti { get; set; }
    }
}