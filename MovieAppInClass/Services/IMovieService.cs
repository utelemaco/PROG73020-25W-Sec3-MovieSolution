using MovieAppInClass.Models;

namespace MovieAppInClass.Services
{
    public interface IMovieService
    {
        void AddMovie(Movie movieToAdd);
        Movie GetMovieById(int movieId);
        List<Movie> GetMovies();
        void UpdateMovie(int movieId, Movie movieToEdit);
    }
}
