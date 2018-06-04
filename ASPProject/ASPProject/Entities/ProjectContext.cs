using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASPProject.Entities
{
    public class ProjectContext : DbContext
    {
        public DbSet<Work> Works { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // configures one-to-many relationship
            modelBuilder.Entity<UserDetails>()
                .HasMany<Task>(s => s.Tasks)
                .WithRequired(g => g.CurrentUser)
                .HasForeignKey<int>(s => s.UserId);

            modelBuilder.Entity<UserDetails>()
                .HasRequired(s => s.User) 
                .WithRequiredPrincipal(ad => ad.UserDetails);

            modelBuilder.Entity<Task>().Property(m => m.UserId).IsOptional();
            base.OnModelCreating(modelBuilder);
        }

        public ProjectContext() : base("ProjectASPDataBase")
        {

        }
    }
}