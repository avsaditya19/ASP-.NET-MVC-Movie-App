using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using IMDB.Models;
using IMDB.Repositories;
using IMDB.ViewModels;
using RestSharp;

namespace IMDB.Controllers
{
    public class MoviesController : Controller
    {       
        private readonly string _apiKey="f30402934abe75b3b7aa8cd8d73bd2ba";
        private readonly IMovieRepository _movieRepository;
        private readonly IActorRepository _actorRepository;
        private readonly IProducerRepository _producerRepository;
        private readonly MovContext _context;
        public MoviesController()
        {
            _context = new MovContext();
            _producerRepository = new ProducerRepository(_context);
            _actorRepository = new ActorRepository(_context);
            _movieRepository = new MovieRepository(_context);
        }

        // GET: Movies
        public ActionResult Index()
        {            
            return View(_movieRepository.GetMovies());
        }

        // GET: Movies/Details/5
        public ActionResult Details(int id)
        {           
            Movie movie = _movieRepository.GetMovieById(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create(Movie movie)
        {
            CreateMovieViewModel model = new CreateMovieViewModel();            
            if (movie.Name!=null)
            {
                Populate n = new Populate();
                Composite pop = n.Popul(movie);
                Producer newproducer = new Producer();
                List<Actor> newactors = new List<Actor>();

                newproducer = pop.Producer;
                newactors = pop.Actors;

                string pname = newproducer.Name;
                Producer producer = _producerRepository.GetProducers().FirstOrDefault(a => a.Name == pname);
                if (producer == null)
                {
                    _producerRepository.InsertProducer(newproducer);
                    _producerRepository.Save();
                }

                List<int> selectedActorIDs = new List<int>();


                List<Actor> actors = _actorRepository.GetActors().ToList();
                List<Actor> tempActors = new List<Actor>();
       
                foreach (var b in newactors)
                {
                    string aname = b.Name;
                    Actor actor = actors.FirstOrDefault(a => a.Name == aname);
                    if (actor == null)
                        tempActors.Add(b);
                    
                }

                foreach(var b in tempActors)
                {
                    _actorRepository.InsertActor(b);
                    _actorRepository.Save();
                }

                actors = _actorRepository.GetActors().ToList();
                //foreach (var b in newactors)
                //    selectedActorIDs.Add(actors.FirstOrDefault(a => a.tmdb_id == b.tmdb_id).ID);

                List<int> toadd = (from na in newactors
                                   join a in actors on na.TmdbId equals a.TmdbId
                                   select a.Id).ToList();

                selectedActorIDs.AddRange(toadd);

                SelectList producerslist = new SelectList(_producerRepository.GetProducers().OrderBy(i => i.Name), "Id", "Name", _producerRepository.GetProducers().FirstOrDefault(a => a.TmdbId == newproducer.TmdbId).Id);
                MultiSelectList actorslist = new MultiSelectList(_actorRepository.GetActors().OrderBy(i => i.Name), "Id", "Name", selectedActorIDs);               
                model.Name = movie.Name;
                model.Plot = movie.Plot;
                model.Year = movie.Year;
                model.Image = movie.Image;
                model.Producers = producerslist;
                model.Actors = actorslist;
                model.TmdbId = movie.TmdbId;

            }
            else
            {
                SelectList producerslist = new SelectList(_producerRepository.GetProducers().OrderBy(i => i.Name), "Id", "Name");
                MultiSelectList actorslist = new MultiSelectList(_actorRepository.GetActors().OrderBy(i => i.Name), "Id", "Name");
                model.Producers = producerslist;
                model.Actors = actorslist;

            }

            return View(model);
        }          

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Year,Plot,Image,ProducerId,ActorIDs,TmdbId")] CreateMovieViewModel model)
        {
            if (ModelState.IsValid)
            {
                Movie movie = new Movie
                {
                    Id = new int(),
                    Name = model.Name,
                    Year = model.Year,
                    Plot = model.Plot,
                    Image = model.Image,
                    TmdbId = model.TmdbId
                    
                };

                var producerId = int.Parse(model.ProducerId);
                //Producer producer = db.Producers.Find(ProducerId);
                Producer producer = _producerRepository.GetProducerById(producerId);
                movie.Producer = producer;

                if(model.ActorIDs!=null)
                {
                    foreach(var id in model.ActorIDs)
                    {
                        var actorId = int.Parse(id);                        
                        var actor = _actorRepository.GetActorById(actorId);
                        try
                        {
                            movie.Actors.Add(actor);
                        }
                        catch(Exception ex)
                        {
                            return View("Error", new HandleErrorInfo(ex, "Movies", "Index"));
                        }                                              
                     }
                }
                try
                {                   
                    _movieRepository.InsertMovie(movie);
                    _movieRepository.Save();
                }
                catch(Exception ex)
                {
                    return View("Error", new HandleErrorInfo(ex, "Movies", "Index"));
                }

                //return RedirectToAction("Details", new { id=movie.ID});
                TempData["Name"] = movie.Name;
                TempData["Method"] = "Create";
                TempData["Exists"] = "true";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Something Failed.");
            return View(model);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int id)
        {            
            Movie movie = _movieRepository.GetMovieById(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Year,Plot,Image")] Movie movie)
        {
            if (ModelState.IsValid)
            {                
                _movieRepository.Save();
                TempData["Name"] = movie.Name;
                TempData["Method"] = "Edit";
                TempData["Exists"] = "true";
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int id)
        {           
            Movie movie = _movieRepository.GetMovieById(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {            
            Movie movie = _movieRepository.GetMovies().Single(e => e.Id == id);
            _movieRepository.DeleteMovie(movie.Id);
            _movieRepository.Save();
            TempData["Name"] = movie.Name;
            TempData["Method"] = "Delete";
            TempData["Exists"] = "true";
            return RedirectToAction("Index");
        }                
        public ActionResult Search()
        {                        
            return View(new List<Movie>());
        } 

        [HttpPost]    
        public ActionResult Search([Bind(Include="query")] string query)
        {            
            string adr = "https://api.themoviedb.org/3/search/movie";
            var str = adr + "?api_key=" + _apiKey + "&language=en-US&query=" + query + "&page=1&include_adult=false";

            var client = new RestClient(str);
            var request = new RestRequest(Method.GET);
            request.AddParameter("undefined", "{}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            List<Movie> movies = new List<Movie>();
            RootObject recievedMovies = new JavaScriptSerializer().Deserialize<RootObject>(response.Content);
            var loopover = recievedMovies.Results; 

            foreach(var b in loopover)
            {
                Movie movie = new Movie();
                movie.Name = b.Title;
                movie.Image = b.PosterPath;
                movie.Plot = b.Overview;
                movie.TmdbId = b.Id;
                                
                string year = "";
                if (b.ReleaseDate != null)
                {
                    foreach (var c in b.ReleaseDate)
                    {
                        if (c == '-')
                            break;
                        year += c;
                    }
                }
                if (year.Length != 0)
                    movie.Year = Convert.ToInt32(year);
                else
                    movie.Year = 0;
                if (movie.Image == null)
                    movie.Image = "";
                movies.Add(movie);
            }            
            return View(movies);
        }
        
        [HttpPost]
        public ActionResult Intermediate([Bind(Include = "Name,Image,Year,Plot,ProducerId,ActorIDs,TmdbId")]Movie movie)
        {

            return RedirectToAction("Create", movie);
        }

        private bool IsValidContentType(string contentType)
        {
            return contentType.Equals("image/png") || contentType.Equals("image/gif") || contentType.Equals("image/jpeg") ||
                contentType.Equals("image/jpg");

        }
        /*
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase photo)
        {
            //if(!isValidContentType(photo.ContentType))
            //{

            //}
            if(photo.ContentLength>0)
            {
                var filename = Path.GetFileName(photo.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Images/"), filename);
                photo.SaveAs(path);
            }
            return RedirectToAction("Index");
        }
        
        */

        protected override void Dispose(bool disposing)
        {
            _movieRepository.Dispose();
            base.Dispose(disposing);
        }
    }   
}



