using MovieApp.Models;

namespace MovieApp.Services
{
    public interface IMovieService
    {
        List<Movie> GetMovies();
        void AddMovie(Movie movie);
        Movie GetMovieById(int id);
        void UpdateMovie(int id, Movie movie);

        void DeleteMovie(int id);
    }
}
