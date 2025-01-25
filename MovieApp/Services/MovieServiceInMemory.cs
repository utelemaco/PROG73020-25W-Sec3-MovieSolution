using MovieApp.Models;

namespace MovieApp.Services
{
    public class MovieServiceInMemory : IMovieService
    {

        private static List<Movie> _movieList = new List<Movie>();
        private static Boolean _loading = false;

        public MovieServiceInMemory() {
            if (!_loading)
            {
                _movieList.Add(new Movie { Id = 1, Title = "Casablanca", Year = 1942, Ratting = 4 });
                _movieList.Add(new Movie { Id = 2, Title = "Back to the Future", Year = 1985, Ratting = 4 });
                _movieList.Add(new Movie { Id = 3, Title = "Ghost", Year = 1986, Ratting = 5 });
                _loading = true;
            }
        }

        public void AddMovie(Movie movie)
        {
            movie.Id = _movieList.Count + 1;
            _movieList.Add(movie);
        }

        public void DeleteMovie(int id)
        {
            Movie? m = _movieList.Find(m => m.Id == id);
            if (m != null)
            {
                _movieList.Remove(m);
            }
        }

        public Movie GetMovieById(int id)
        {
            Movie? m = _movieList.Find(m => m.Id == id);
            if (m == null)
            {
                return new Movie();
            }
            return m;
        }

        public void UpdateMovie(int id, Movie movie)
        {
            Movie movieInMemory = GetMovieById(id);
            movieInMemory.Title = movie.Title;
            movieInMemory.Year = movie.Year;
            movieInMemory.Ratting = movie.Ratting;
        }

        List<Movie> IMovieService.GetMovies()
        {
            return _movieList;
        }
    }
}
