using System;
using System.Collections.Generic;
using IMDB.Models;

namespace IMDB.Repositories
{
    interface IMovieRepository : IDisposable
    {
        IEnumerable<Movie> GetMovies();
        Movie GetMovieById(int movieId);
        void InsertMovie(Movie movie);
        void DeleteMovie(int movieId);
        void UpdateMovie(Movie movie);
        void Save();
    }

}