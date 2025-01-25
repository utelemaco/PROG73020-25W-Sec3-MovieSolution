using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;
using MovieApp.Services;

namespace MovieApp.Controllers
{
    
    public class MovieController : Controller
    {
        private readonly IMovieService movieService = new MovieServiceInMemory();


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            return View(movieService.GetMovies());
        }

        [HttpGet]
        public IActionResult Add(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Movie movieToAdd)
        {
            movieService.AddMovie(movieToAdd);
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Movie movieToEdit = movieService.GetMovieById(id);
            return View(movieToEdit);
        }

        [HttpPost]
        public IActionResult Edit(int id, Movie movieToUpdate)
        {
            movieService.UpdateMovie(id, movieToUpdate);
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult PrepareDelete(int id)
        {
            Movie movieToDelete = movieService.GetMovieById(id);
            return View(movieToDelete);
        }

        [HttpGet]
        public IActionResult ConfirmDelete(int id)
        {
            movieService.DeleteMovie(id);
            return RedirectToAction("List");
        }

    }
}
