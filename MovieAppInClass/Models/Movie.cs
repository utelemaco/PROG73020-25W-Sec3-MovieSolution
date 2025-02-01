using System.ComponentModel.DataAnnotations;

namespace MovieAppInClass.Models
{
    public class Movie
    {
        //Eventually the PK
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public int? Year { get; set; }
        public int Ratting { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage ="Choose a Genre")]
        public int GenreId { get; set; }

        public Genre? Genre { get; set; }

    }
}
