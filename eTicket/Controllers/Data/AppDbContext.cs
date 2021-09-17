using eTicket.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicket.Controllers.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Configure primary key for the joining table
            modelBuilder.Entity<ActorMovie>().HasKey(am => new
            {
                am.ActorId,
                am.MovieId
            });

            //Configure relationship between the joining table 
            modelBuilder.Entity<ActorMovie>()
                 .HasOne(m => m.Movie)
                 .WithMany(am => am.ActorMovies)
                 .HasForeignKey(m => m.MovieId); // Foreign key  to movie is the Movie Id

            modelBuilder.Entity<ActorMovie>()
                .HasOne(m => m.Actor)
                .WithMany(am => am.ActorMovies)
                .HasForeignKey(m => m.ActorId);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<ActorMovie> ActorMovies { get; set; }

    }
}
