using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace IMDB.ViewModels
{
    public class CreateMovieViewModel
    {
        public CreateMovieViewModel()
        {
            TmdbId = 0;
        }
        [Required]
        [Display(Name="Movie Name")]
        public string Name { get; set; }
        public string Plot { get; set; }
        public int Year { get; set; }
        public string Image { get; set; }

        
        public string ProducerId { get; set; }

        [Display(Name = "Producers")]
        public SelectList Producers { get; set; }

        public List<string> ActorIDs { get; set; }

        [Display(Name = "Actors")]
        public MultiSelectList Actors { get; set; }

        public int? TmdbId { get; set; }
    }


    public class EditMovieViewModel : CreateMovieViewModel
    {
        public string MovieId { get; set; }
    }
}