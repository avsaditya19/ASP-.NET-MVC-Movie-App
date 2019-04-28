using System.Web.Mvc;
using IMDB.Models;
using IMDB.Repositories;

namespace IMDB.Controllers
{
    public class ActorsController : Controller
    {        
        private readonly IActorRepository _actorRepository;
        private IMovieRepository _movieRepository;
        private IProducerRepository _producerRepository;

        public ActorsController()
        {
            var context = new MovContext();
            _producerRepository = new ProducerRepository(context);
            _actorRepository = new ActorRepository(context);
            _movieRepository = new MovieRepository(context);
        }

        // GET: Actors
        public ActionResult Index()
        {
            return View(_actorRepository.GetActors());              
        }

        // GET: Actors/Details/5
        public ActionResult Details(int id)
        {           
            Actor actor = _actorRepository.GetActorById(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        // GET: Actors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Actors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Sex,Dob,Bio")] Actor actor)
        {
            if (ModelState.IsValid)
            {
                _actorRepository.InsertActor(actor);
                _actorRepository.Save();                
                //return RedirectToAction("Index");              
            }

            //return View(actor);
            return Json(new { ID = actor.Id , actor.Name  });
        }

        // GET: Actors/Edit/5
        public ActionResult Edit(int id)
        {
            Actor actor = _actorRepository.GetActorById(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        // POST: Actors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Sex,Dob,Bio")] Actor actor)
        {
            if (ModelState.IsValid)
            {                
                _actorRepository.Save(); 
                return RedirectToAction("Index");
            }
            
            return View(actor);
        }

        // GET: Actors/Delete/5
        public ActionResult Delete(int id)
        {            
            Actor actor = _actorRepository.GetActorById(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        // POST: Actors/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Actor actor = _actorRepository.GetActorById(id);
            _actorRepository.DeleteActor(actor.Id);
            _actorRepository.Save();

            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            _actorRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
