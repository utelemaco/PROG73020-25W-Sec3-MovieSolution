using Microsoft.EntityFrameworkCore;

namespace MovieApp.Models
{
    public class MovieContext: DbContext
    {

        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
        { }

        public DbSet<Movie> Movie { get; set; } = null;

        public DbSet<User> User { get; set; }

        public DbSet<Genre> Genre { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // seed the DB w 3 movies:
            modelBuilder.Entity<Movie>().HasData(
                new Movie() { Id = 1, Title = "Annie Hall", GenreId = 3, Year = 1977, Ratting = 5 },
                new Movie() { Id = 2, Title = "Apocalypse Now", GenreId = 3, Year = 1979, Ratting = 4 },
                new Movie() { Id = 3, Title = "Casablanca", GenreId = 1, Year = 1942, Ratting = 5 }
            );

            // seed the DB w 2 users:
            modelBuilder.Entity<User>().HasData(
                new User() { Id = 1, Name = "Admin" },
                new User() { Id = 2, Name = "User"}
            );

            modelBuilder.Entity<Genre>().HasData(
                new Genre() { Id = 1, Name = "Drama" },
                new Genre() { Id = 2, Name = "Comedy" },
                new Genre() { Id = 3, Name = "Action" }
                );
        }
    }
}
