namespace Projekat.Models
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class AspNetOrganizacijaContext : DbContext
	{
		public AspNetOrganizacijaContext()
			: base("name=OrganizacijaModel")
		{
		}

		public virtual DbSet<AspNetOrganizacijaModels> AspNetOrganizacijaModels { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
		}
	}
}
