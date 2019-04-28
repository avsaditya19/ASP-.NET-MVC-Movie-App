using System;
using System.Collections.Generic;
using IMDB.Models;

namespace IMDB.Repositories
{
    interface IProducerRepository : IDisposable
    {
        IEnumerable<Producer> GetProducers();
        Producer GetProducerById(int producerId);
        void InsertProducer(Producer producer);
        void DeleteProducer(int producerId);
        void UpdateProducer(Producer producer);
        void Save();
    }
}
