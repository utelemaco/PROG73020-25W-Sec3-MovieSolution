using MovieAppInClass.Models;

namespace MovieAppInClass.Services
{
    public class MovieServiceInMemory : IMovieService
    {
        private static List<Movie> _movies = new List<Movie>();
        private static Boolean _starting = true;
        public MovieServiceInMemory() {
            if (_starting)
            {
                _movies.Add(new Movie { Id = 1, Title = "Avatar 1", Year = 2004, Ratting = 4 });
                _movies.Add(new Movie { Id = 2, Title = "Avatar 2", Year = 2024, Ratting = 4 });
                _movies.Add(new Movie { Id = 3, Title = "Avengers 1", Year = 2008, Ratting = 5 });
                _starting = false;
            }
        }

        public void AddMovie(Movie movieToAdd)
        {
            _movies.Add(movieToAdd);
        }

        public Movie GetMovieById(int movieId)
        {
            Movie? m = _movies.Find(m => m.Id == movieId);
            if (m == null)
            {
                return new Movie();
            }
            return m;
        }

        public List<Movie> GetMovies()
        {
            return _movies;
        }

        public void RemoveMove(int movieId)
        {
            _movies.Remove(GetMovieById(movieId));
        }

        public void UpdateMovie(int movieId, Movie movieToEdit)
        {
            Movie movieInMemory = GetMovieById(movieId);
            movieInMemory.Title = movieToEdit.Title;
            movieInMemory.Year = movieToEdit.Year;
            movieInMemory.Ratting = movieToEdit.Ratting;
        }
    }
}
