using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepositaryLayer.Entity;

namespace RepositaryLayer.Context
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions options)
            : base(options)
        {

        } 
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Collabrators>()
                .HasKey(e => new { e.Collaborator_Id });
            modelBuilder.Entity<Collabrators>()
                .HasOne(e => e.Notes)
                .WithMany(e => e.Collabrators)
                .HasForeignKey(e => e.Notes_Id);
            modelBuilder.Entity<Collabrators>()
                .HasOne(e =>e.Users )
                .WithMany(e => e.Collabrators)
                .HasForeignKey(e => e.User_Id);

            modelBuilder.Entity<Lables>()
                .HasKey(e => new { e.Lable_Id });
            modelBuilder.Entity<Lables>()
                .HasOne(e => e.Notes)
                .WithMany(e => e.Lables)
                .HasForeignKey(e => e.Notes_Id);
            modelBuilder.Entity<Lables>()
                .HasOne(e => e.Users)
                .WithMany(e => e.Lables)
                .HasForeignKey(e => e.User_Id);

        }
        public DbSet<Users> User { get; set; }
        public DbSet<Notes> Note { get; set; }
        public DbSet<Collabrators> Collabrator { get; set; }
        public DbSet<Lables> Lables { get; set; }


    }
}
