using System.Collections.Generic;

namespace IMDB.ViewModels
{
    public class PopulateJson
    {

        public class Cast
        {
            public int CastId { get; set; }
            public string Character { get; set; }
            public string CreditId { get; set; }
            public int Gender { get; set; }
            public int Id { get; set; }
            public string Name { get; set; }
            public int Order { get; set; }
            public string ProfilePath { get; set; }
        }

        public class Crew
        {
            public string CreditId { get; set; }
            public string Department { get; set; }
            public int Gender { get; set; }
            public int Id { get; set; }
            public string Job { get; set; }
            public string Name { get; set; }
            public string ProfilePath { get; set; }
        }

        public class RootObjectTwo
        {
            public int Id { get; set; }
            public List<Cast> Cast { get; set; }
            public List<Crew> Crew { get; set; }
        }
    }
}