namespace Projekat.Models
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class VideoContext : DbContext
	{
		public VideoContext()
			: base("name=VideoContext")
		{
		}

		public virtual DbSet<videoModels> videoModels { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
		}
	}
}
