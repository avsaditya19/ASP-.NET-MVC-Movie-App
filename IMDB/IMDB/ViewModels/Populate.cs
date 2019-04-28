using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using IMDB.Models;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace IMDB.ViewModels
{
    public class Populate
    {
        private readonly string _apiKey = "f30402934abe75b3b7aa8cd8d73bd2ba";
        public Composite Popul(Movie movie)
        {
            if (movie == null)
                return new Composite();
            var tmdbId = movie.TmdbId;
            var client = new RestClient("https://api.themoviedb.org/3/movie/" + tmdbId + "/credits?api_key=" + _apiKey);
            var request = new RestRequest(Method.GET);
            request.AddParameter("undefined", "{}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            List<int> castIDs = new List<int>();
            PopulateJson.RootObjectTwo recievedPopulates = new JavaScriptSerializer().Deserialize<PopulateJson.RootObjectTwo>(response.Content);
            var castLoop = recievedPopulates.Cast;
            int i = 0;

            foreach (var b in castLoop)
            {
                castIDs.Add(b.Id);
                i++;
                if (i > 4)
                    break;
            }

            int crewId = recievedPopulates.Crew.First().Id;
            Producer producer = Producersearch(crewId);
            List<Actor> actors = new List<Actor>();
            foreach (var b in castIDs)
            {
                Actor actor = Actorsearch(b);
                actors.Add(actor);
            }
            Composite comp = new Composite
            {
                Producer = producer,
                Actors = actors
            };

            return comp;
        }
        public Actor Actorsearch(int id)
        {
            var client = new RestClient("https://api.themoviedb.org/3/person/" + id + "?api_key=" + _apiKey + "&language=en-US");
            var request = new RestRequest(Method.GET);
            request.AddParameter("undefined", "{}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            dynamic a = JObject.Parse(response.Content);
            Actor actor = new Actor
            {
                Name = a["name"],
                Dob = a["birthday"],
                Bio = a["biography"],
                TmdbId = id,
                Sex = a["gender"] == 2 ? "M" : "F"
            };

            return actor;
        }
        public Producer Producersearch(int id)
        {
            var client = new RestClient("https://api.themoviedb.org/3/person/" + id + "?api_key=" + _apiKey + "&language=en-US");
            var request = new RestRequest(Method.GET);
            request.AddParameter("undefined", "{}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            dynamic p = JObject.Parse(response.Content);
            Producer producer = new Producer
            {
                Name = p["name"],
                TmdbId = id,
                Bio = p["biography"],
                Dob = p["birthday"],
                Sex = p["gender"] == 2 ? "M" : "F"
            };

            return producer;
        }

    }
}