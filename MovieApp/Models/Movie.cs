using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? Ratting { get; set; }
        public int? Year { get; set; }

        [Required(ErrorMessage = "Please choose a Genre to the movie")]
        [Range(1, int.MaxValue, ErrorMessage = "Please choose a Genre to the movie")]
        public int GenreId { get; set; }

        [ValidateNever]
        public Genre Genre { get; set; } = null!;
    }
}
