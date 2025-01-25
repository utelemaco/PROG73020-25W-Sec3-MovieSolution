using MovieAppInClass.Models;

namespace MovieAppInClass.Services
{
    public interface IMovieService
    {
        void AddMovie(Movie movieToAdd);
        List<Movie> GetMovies();
    }
}
