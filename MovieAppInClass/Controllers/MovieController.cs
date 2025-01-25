using Microsoft.AspNetCore.Mvc;
using MovieAppInClass.Models;
using MovieAppInClass.Services;

namespace MovieAppInClass.Controllers
{
    public class MovieController : Controller
    {
        IMovieService movieService = new MovieServiceInMemory();

        public IActionResult List()
        {
            return View(movieService.GetMovies());
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
            movieService.AddMovie(movieToAdd);
            
            //If request OK
            return RedirectToAction("List");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(movieService.GetMovieById(id));
        }

        [HttpPost]
        public IActionResult Edit(int id, Movie movieToEdit)
        {
            //Add Movie into the catalogue
            movieService.UpdateMovie(id, movieToEdit);

            //If request OK
            return RedirectToAction("List");
        }




    }


}
