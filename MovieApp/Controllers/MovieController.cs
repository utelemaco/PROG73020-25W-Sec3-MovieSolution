using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;
using MovieApp.Services;

namespace MovieApp.Controllers
{
    
    public class MovieController : Controller
    {
        private readonly IMovieService movieService = new MovieServiceInMemory();
        private readonly MovieContext _movieContext;

        public MovieController(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            var movies = _movieContext.Movie
                .Include(m => m.Genre)
                .OrderBy(m => m.Title).ToList();
            return View(movies);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Genres = _movieContext.Genre.OrderBy(g => g.Name).ToList(); 
            return View();
        }

        [HttpPost]
        public IActionResult Add(Movie movieToAdd)
        {
            if (!ModelState.IsValid)
            {
                return Add();
            }
            _movieContext.Movie.Add(movieToAdd);
            _movieContext.SaveChanges();
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            //Movie movieToEdit = movieService.GetMovieById(id);
            Movie movieToEdit = _movieContext.Movie.Find(id);
            ViewBag.Genres = _movieContext.Genre.OrderBy(g => g.Name).ToList();
            return View(movieToEdit);
        }

        [HttpPost]
        public IActionResult Edit(int id, Movie movieToUpdate)
        {
            //movieService.UpdateMovie(id, movieToUpdate);
            _movieContext.Movie.Update(movieToUpdate);
            _movieContext.SaveChanges();
            return RedirectToAction("List");
        }


        [HttpGet]
        public IActionResult PrepareDelete(int id)
        {
            Movie movieToDelete = _movieContext.Movie.Find(id);
            return View("Delete", movieToDelete);
        }

        [HttpGet]
        public IActionResult ConfirmDelete(int id)
        {
            Movie movieToDelete = _movieContext.Movie.Find(id);
            _movieContext.Movie.Remove(movieToDelete);
            _movieContext.SaveChanges();
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Search(string title)
        {
            List<Movie> movies = _movieContext.Movie
                .Where(m => m.Title.StartsWith(title))
                .ToList();
            ViewBag.SearchTitle = title;
            return View("List", movies);
        }

    }
}
