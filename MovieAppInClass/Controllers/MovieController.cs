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
    }
}
