using System.Web.Mvc;
using IMDB.Models;
using IMDB.Repositories;

namespace IMDB.Controllers
{
    public class HomeController : Controller
    {
        private IMovieRepository _movieRepository;
        private IActorRepository _actorRepository;
        private IProducerRepository _producerRepository;

        public HomeController()
        {
            _actorRepository = new ActorRepository(new MovContext());
            _movieRepository = new MovieRepository(new MovContext());
            _producerRepository = new ProducerRepository(new MovContext());              

        }
        public ActionResult Index()
        {
            ViewBag.Message = "Movies Index";
            return RedirectToAction("Index", "Movies");
            //return View();
        }

        public ActionResult Producers()
        {
            ViewBag.Message = "Producers Index";
            return RedirectToAction("Index","Producers");
            //return View();
        }

        public ActionResult Actors()
        {
            ViewBag.Message = "Actors Index";
            return RedirectToAction("Index","Actors");
            //return View();
        }
       
    }

}