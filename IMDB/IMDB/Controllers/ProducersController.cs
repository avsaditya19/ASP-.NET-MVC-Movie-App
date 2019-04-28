using System.Web.Mvc;
using IMDB.Models;
using IMDB.Repositories;

namespace IMDB.Controllers
{
    public class ProducersController : Controller
    {
        private IActorRepository _actorRepository;
        private IMovieRepository _movieRepository;
        private readonly IProducerRepository _producerRepository;

        public ProducersController()
        {
            var context = new MovContext();
            _producerRepository = new ProducerRepository(context);
            _actorRepository = new ActorRepository(context);
            _movieRepository = new MovieRepository(context);
        }

        // GET: Producers
        public ActionResult Index()
        {            
            return View(_producerRepository.GetProducers());
        }

        // GET: Producers/Details/5
        public ActionResult Details(int id)
        {            
            Producer producer = _producerRepository.GetProducerById(id);
            if (producer == null)
            {
                return HttpNotFound();
            }
            return View(producer);
        }

        // GET: Producers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Producers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Sex,Dob,Bio")] Producer producer)
        {
            if (ModelState.IsValid)
            {
                _producerRepository.InsertProducer(producer);
                _producerRepository.Save();
                //return RedirectToAction("Index");
            }

            //return View(producer);
            return Json(new { ID = producer.Id, producer.Name });
        }

        // GET: Producers/Edit/5
        public ActionResult Edit(int id)
        {            
            Producer producer = _producerRepository.GetProducerById(id);
            if (producer == null)
            {
                return HttpNotFound();
            }
            return View(producer);
        }

        // POST: Producers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Sex,Dob,Bio")] Producer producer)
        {
            if (ModelState.IsValid)
            {                
                _producerRepository.Save();
                return RedirectToAction("Index");
            }
            return View(producer);
        }

        // GET: Producers/Delete/5
        public ActionResult Delete(int id)
        {            
            Producer producer = _producerRepository.GetProducerById(id);
            if (producer == null)
            {
                return HttpNotFound();
            }
            return View(producer);
        }

        // POST: Producers/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producer producer = _producerRepository.GetProducerById(id);
            _producerRepository.DeleteProducer(producer.Id);
            _producerRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _producerRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
