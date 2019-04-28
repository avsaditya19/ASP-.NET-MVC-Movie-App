using System.Collections.Generic;
using IMDB.Models;

namespace IMDB.ViewModels
{
    public class Composite
    {
        public Producer Producer { get; set; }
        public List<Actor> Actors { get; set; }

    }

}