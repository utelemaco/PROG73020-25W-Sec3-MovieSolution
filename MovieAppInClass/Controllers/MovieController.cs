using Microsoft.AspNetCore.Mvc;
using MovieAppInClass.Models;
using MovieAppInClass.Services;

namespace MovieAppInClass.Controllers
{
    public class MovieController : Controller
    {
        IMovieService movieService = new MovieServiceInMemory();

        private readonly MovieDbContext movieDbContext;

        public MovieController(MovieDbContext movieDbContext)
        {
            this.movieDbContext = movieDbContext;
        }

        public IActionResult List()
        {
            var movies = movieDbContext.Movie
                .OrderBy (m => m.Title)
                .ToList();
            return View(movies);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new Movie());
        }

        [HttpPost]
        public IActionResult Add(Movie movieToAdd)
        {
            //Add Movie into the catalogue
            //movieService.AddMovie(movieToAdd);
            movieDbContext.Movie.Add(movieToAdd);
            movieDbContext.SaveChanges();
            
            //If request OK
            return RedirectToAction("List");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movieToEdit = movieDbContext.Movie.Find(id);
            return View(movieToEdit);
        }

        [HttpPost]
        public IActionResult Edit(int id, Movie movieToEdit)
        {
            //Add Movie into the catalogue
            //movieService.UpdateMovie(id, movieToEdit);
            movieDbContext.Movie.Update(movieToEdit);
            movieDbContext.SaveChanges();

            //If request OK
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult PrepareDelete(int id)
        {
            var movieToDelete = movieDbContext.Movie.Find(id);
            return View("Delete", movieToDelete);
        }

        [HttpGet]
        public IActionResult ConfirmDelete(int id)
        {
            var movieToDelete = movieDbContext.Movie.Find(id);
            movieDbContext.Movie.Remove(movieToDelete);
            movieDbContext.SaveChanges();
            return RedirectToAction("List");
        }




    }


}
