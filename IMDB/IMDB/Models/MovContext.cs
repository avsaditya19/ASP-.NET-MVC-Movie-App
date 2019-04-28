using System.Data.Entity;

namespace IMDB.Models
{
    public class MovContext : DbContext 
    {
        public MovContext() : base("name=DbConnectionString") { }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Producer> Producers { get; set; }



    }
}