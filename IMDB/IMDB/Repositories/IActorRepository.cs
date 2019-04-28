using System;
using System.Collections.Generic;
using IMDB.Models;

namespace IMDB.Repositories
{
    interface IActorRepository : IDisposable
    {
        IEnumerable<Actor> GetActors();
        Actor GetActorById(int actorId);
        void InsertActor(Actor actor);
        void DeleteActor(int actorId);
        void UpdateActor(Actor actor);
        void Save();
    }
}
