using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using Vidly.Web.Models;
using Vidly.Web.ViewModels;

namespace Vidly.Web.Controllers
{
    public class MoviesController : Controller
    {
        public ApplicationDbContext _context { get; set; }

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Movies
        public ActionResult Random()
        {

            var movie = new Movie() { Name = "Shrek!" };

            var customers = new List<Customer>
            {
                new Customer{Name = "Customer 1"},
                new Customer{Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel);
        }

        [Route("movies/released/{year:regex(2015|2016)}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovie))
                return View("List");
                        
             return View("ReadOnlyList");
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include("Genre").SingleOrDefault(c => c.Id == id);
            return View(movie);
        }

        [Authorize(Roles = RoleName.CanManageMovie)]
        public ActionResult New()
        {
            var viewModel = new MovieFormViewModel
            {
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageMovie)]
        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }
            if(movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(x => x.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.Count = movie.Count;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        [Authorize(Roles = RoleName.CanManageMovie)]
        public ActionResult Edit(int id)
        {
            var genres = _context.Genres.ToList();
            var movie = _context.Movies.Single(x => x.Id == id);
            if (movie == null)
                return HttpNotFound();
            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = genres,
            };
            return View("MovieForm", viewModel);
        }
    }
}