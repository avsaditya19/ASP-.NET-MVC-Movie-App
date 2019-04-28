using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IMDB.Models
{
    public sealed class Movie
    {
        public Movie()
        {
            Actors = new List<Actor>();
            Producer = new Producer();
            TmdbId = 0;
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required.")]
        [StringLength(80, ErrorMessage = "Movie Name cannot be longer than 80 characters.")]
        public string Name { get; set; }

        [Range(1600,2020, ErrorMessage = "Enter Year Between 1600-2000")]
        public int Year { get; set; }

        [StringLength(5000, ErrorMessage = "Plot cannot be longer than 5000 characters.")]
        public string Plot { get; set; }

        public string Image { get; set; }
        

        public Producer Producer { get; set; }
        public List<Actor> Actors { get; set; }
        
        public int? TmdbId { get; set; } 
    }

}