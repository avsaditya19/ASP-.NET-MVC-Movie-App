using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using IMDB.Models;

namespace IMDB.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovContext _context;

        public MovieRepository(MovContext movContext)
        {
            _context = movContext;
        }
        public void DeleteMovie(int movieId)
        {
            Movie movie = _context.Movies.Find(movieId);
            if (movie != null)
                _context.Movies.Remove(movie);
            else
                throw new IndexOutOfRangeException();
        }

        public Movie GetMovieById(int movieId)
        {
            return _context.Movies.Find(movieId);
        }

        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movies.Include("Producer").ToList();
        }

        public void InsertMovie(Movie movie)
        {
            _context.Movies.Add(movie);
        }
        public void UpdateMovie(Movie movie)
        {
            _context.Entry(movie).State = EntityState.Modified;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        private bool _disposed;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}