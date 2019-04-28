using System.Collections.Generic;
using System.Data.Entity.Migrations;
using IMDB.Models;

namespace IMDB.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MovContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MovContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var producer1 = new Producer { Name = "Steven Spielberg", Dob = "18 December 1946", Sex = "M", Bio = "Steven Allan Spielberg, KBE, OMRI is an American director, producer, and screenwriter. He is considered one of the founding pioneers of the New Hollywood era" };
            var producer2 = new Producer { Name = "Tim Burton", Dob = "25 August 1958", Sex = "F", Bio = "Steven Allan Spielberg, KBE, OMRI is an American director, producer, and screenwriter. He is considered one of the founding pioneers of the New Hollywood era" };

            context.Producers.AddOrUpdate(
                p=> p.Id,
                producer1,
                producer2
                );
                

            var actor1 = new Actor { Name = "Leonardo DiCaprio", Dob = "11 November 1974", Sex = "M", Bio = "Leonardo Wilhelm DiCaprio is an American actor and film producer. DiCaprio began his career by appearing in television commercials in the early 1990s" };
            var actor2 = new Actor { Name = "Amy Adams", Dob = "August 20 1974", Sex = "F", Bio = "Amy Lou Adams (born August 20, 1974) is an American actress and singer. She was named one of 100 most influential people by Time magazine in 2014 and is among the highest-paid actresses in the world." };
            var actor3 = new Actor { Name = "Eva Green", Dob = "6 July 1980", Sex = "F", Bio = "Eva Gaëlle Green is a French actress and model. She started her career in theatre before making her film debut in 2003 in Bernardo Bertolucci's film The Dreamers. " };
            var actor4 = new Actor { Name = "Johnny Depp", Dob = "9 June 1963", Sex = "M", Bio = "John Christopher 'Johnny' Depp II is an American actor, producer, and musician. He has won the Golden Globe Award and Screen Actors Guild Award for Best Actor." };

            context.Actors.AddOrUpdate(
                a=>a.Id,
                actor1,
                actor2,
                actor3,
                actor4
                );

            /*
            context.Actors.Add(actor1);
            context.Actors.Add(actor2);
            context.Actors.Add(actor3);
            context.Actors.Add(actor4); */

            var movie1 = new Movie { Name = "Catch Me If You Can", Year = 2002, Producer = producer1, Actors = new List<Actor> { actor1, actor2 }, Plot = "Frank Abagnale Jr is a con man who poses as a pilot, doctor and lawyer and cashes forged cheques worth millions before his 21st birthday, despite being constantly chased by FBI agent Carl Hanratty.", Image = "https://upload.wikimedia.org/wikipedia/en/4/4d/Catch_Me_If_You_Can_2002_movie.jpg" };
            var movie2 = new Movie { Name = "Edward Scissorhands", Year = 1990, Producer = producer2, Actors = new List<Actor> { actor4 }, Plot = "Edward, a synthetic man with scissor hands, is taken in by Peg, a kindly Avon lady, after the passing of his inventor. Things take a turn for the worse when he is blamed for a crime he did not commit.", Image = "http://www.gstatic.com/tv/thumb/movieposters/12902/p12902_p_v8_ar.jpg" };
            var movie3 = new Movie { Name = "Miss Peregrine's Home for Peculiar Children", Year = 2016, Producer = producer2, Actors = new List<Actor> { actor3 }, Plot = "When his beloved grandfather leaves Jake clues to a mystery that spans different worlds and times, he finds a magical place known as Miss Peregrine's School for Peculiar Children. But the mystery and danger deepen as he gets to know the residents and learns about their special powers", Image = "http://t0.gstatic.com/images?q=tbn:ANd9GcRToZ_GjKrNBI8-r2z2W3kr0uu31fCkDE0MtdDXxrYzeodmVx-j" };

            context.Movies.AddOrUpdate(
                m=>m.Id,
                movie1,
                movie2,
                movie3
                );

            /*
            context.Movies.Add(movie1);
            context.Movies.Add(movie2);
            context.Movies.Add(movie3); */


            context.SaveChanges();
        }
    }
}
