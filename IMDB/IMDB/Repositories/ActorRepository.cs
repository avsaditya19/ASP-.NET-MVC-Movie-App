using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using IMDB.Models;

namespace IMDB.Repositories
{
    public class ActorRepository : IActorRepository
    {
        private readonly MovContext _context;

        public ActorRepository(MovContext movContext)
        {
            _context = movContext;
        }
        public void DeleteActor(int actorId)
        {
            Actor actor = _context.Actors.Find(actorId);
            if (actor != null)
                _context.Actors.Remove(actor);
            else
                throw new IndexOutOfRangeException();
        }

        public Actor GetActorById(int actorId)
        {
            return _context.Actors.Find(actorId);
        }

        public IEnumerable<Actor> GetActors()
        {
            return _context.Actors.ToList();
        }

        public void InsertActor(Actor actor)
        {
            _context.Actors.Add(actor);
        }

        public void UpdateActor(Actor actor)
        {
            _context.Entry(actor).State = EntityState.Modified;
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