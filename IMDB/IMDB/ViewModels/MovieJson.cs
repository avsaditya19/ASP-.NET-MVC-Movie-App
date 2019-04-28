using System.Collections.Generic;

namespace IMDB.ViewModels
{
   public class Result
    {
        public string PosterPath { get; set; }
        public bool Adult { get; set; }
        public string Overview { get; set; }
        public string ReleaseDate { get; set; }
        public List<object> GenreIds { get; set; }
        public int Id { get; set; }
        public string OriginalTitle { get; set; }
        public string OriginalLanguage { get; set; }
        public string Title { get; set; }
        public string BackdropPath { get; set; }
        public double Popularity { get; set; }
        public int VoteCount { get; set; }
        public bool Video { get; set; }
        public double VoteAverage { get; set; }
    }

    public class RootObject
    {
        public int Page { get; set; }
        public List<Result> Results { get; set; }
        public int TotalResults { get; set; }
        public int TotalPages { get; set; }
    }

}