namespace MovieAppInClass.Models
{
    public class Movie
    {
        //Eventually the PK
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public int Ratting { get; set; }

        public int GenreId { get; set; }

        public Genre? Genre { get; set; }

    }
}
