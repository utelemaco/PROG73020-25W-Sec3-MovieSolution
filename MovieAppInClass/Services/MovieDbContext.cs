﻿using Microsoft.EntityFrameworkCore;
using MovieAppInClass.Models;

namespace MovieAppInClass.Services
{
    public class MovieDbContext: DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            : base(options)
        { }

        public DbSet<Movie> Movie { get; set; }

        //Marking genre as an entity
        public DbSet<Genre> Genre { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                    new Movie() { Id = 1, Title = "Annie Hall", Year = 1977, Ratting = 5, GenreId = 2  },
                    new Movie() { Id = 2, Title = "Apocalypse Now", Year = 1979, Ratting = 4, GenreId = 1 },
                    new Movie() { Id = 3, Title = "Casablanca", Year = 1942, Ratting = 5, GenreId = 3 }
                );

            //populating entity Genre
            modelBuilder.Entity<Genre>().HasData(
                    new Genre() { Id = 1, Name = "Action" },
                    new Genre() { Id = 2, Name = "Comedy" },
                    new Genre() { Id = 3, Name = "Drama" }
                );
        }
    }
}
