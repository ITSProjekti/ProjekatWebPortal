namespace Projekat.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ForumContext : DbContext
    {
        public ForumContext()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Forum_Post> Forum_Post { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Forum_Post)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId_Fk)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Forum_Post>()
                .Property(e => e.approved)
                .IsUnicode(false);
        }
    }
}
