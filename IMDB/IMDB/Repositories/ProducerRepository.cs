using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using IMDB.Models;

namespace IMDB.Repositories
{
    public class ProducerRepository : IProducerRepository
    {
        private readonly MovContext _context;
        public ProducerRepository(MovContext movContext)
        {
            _context = movContext;
        }

        public void DeleteProducer(int producerId)
        {
            Producer producer = _context.Producers.Find(producerId);
            if (producer != null)
                _context.Producers.Remove(producer);
            else
                throw new IndexOutOfRangeException();
        }

        public Producer GetProducerById(int producerId)
        {
            return _context.Producers.Find(producerId);
        }

        public IEnumerable<Producer> GetProducers()
        {
            return _context.Producers.ToList();
        }

        public void InsertProducer(Producer producer)
        {
            _context.Producers.Add(producer);
        }

        public void UpdateProducer(Producer producer)
        {
            _context.Entry(producer).State = EntityState.Modified;
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