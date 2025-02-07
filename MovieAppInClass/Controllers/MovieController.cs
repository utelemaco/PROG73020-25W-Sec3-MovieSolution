using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieAppInClass.Models;
using MovieAppInClass.Services;
using System.Data;

namespace MovieAppInClass.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService movieService;

        private readonly MovieDbContext movieDbContext;

        public MovieController(MovieDbContext movieDbContext, IMovieService movieService)
        {
            this.movieDbContext = movieDbContext;
            this.movieService = movieService;
        }

        public IActionResult List()
        {
            var movies = movieDbContext.Movie
                .Include("Genre")
                .OrderBy (m => m.Title)
                .ToList();
            return View(movies);
        }

        [HttpPost]
        public IActionResult Search(string? SearchTitle)
        {
            if (SearchTitle == null)
            {
                var allmovies = movieDbContext.Movie
                .Include("Genre")
                .OrderBy(m => m.Title)
                .ToList();
                return View(allmovies);
            }
            ViewBag.SearchTitle = SearchTitle;
            var movies = movieDbContext.Movie
                .Include("Genre")
                .Where(m => m.Title.StartsWith(SearchTitle))
                .OrderBy(m => m.Title)
                .ToList();
            return View("List", movies);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Genres = movieDbContext.Genre
                .OrderBy(g => g.Name)
                .ToList();
            return View(new Movie());
        }

        [HttpPost]
        public IActionResult Add(Movie movieToAdd)
        {
            if (!ModelState.IsValid) 
            {
                ViewBag.Genres = movieDbContext.Genre
                    .OrderBy(g => g.Name)
                    .ToList();
                return View(movieToAdd);
            }

            //Everything is OKay... move on
            //Add Movie into the catalogue
            //movieService.AddMovie(movieToAdd);
            movieDbContext.Movie.Add(movieToAdd);
            movieDbContext.SaveChanges();
            TempData["LastActionMessage"] = $"\"{movieToAdd.Title}\" added successfully";
            //If request OK
            return RedirectToAction("List");

        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Genres = movieDbContext.Genre
                .OrderBy(g => g.Name)
                .ToList();
            var movieToEdit = movieDbContext.Movie.Find(id);
            return View(movieToEdit);
        }

        [HttpPost]
        public IActionResult Edit(int id, Movie movieToEdit)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Genres = movieDbContext.Genre
                    .OrderBy(g => g.Name)
                    .ToList();
                return View(movieToEdit);
            }
            //Add Movie into the catalogue
            //movieService.UpdateMovie(id, movieToEdit);
            
            movieDbContext.Movie.Update(movieToEdit);
            movieDbContext.SaveChanges();
            TempData["LastActionMessage"] = $"\"{movieToEdit.Title}\" updated successfully";
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
            TempData["LastActionMessage"] = $"\"{movieToDelete.Title}\" removed successfully";
            return RedirectToAction("List");
        }




    }


}
