using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller


    {

        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext(); 
        }


        // GET: Movies/Random
        [Route("movies/Random")]
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shreak!" };
            //var customers = new List<Customer> { new Customer { Name = "Customer 1" }, 
            //new Customer { Name = "Customer 2" } };

            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1"},
                new Customer { Name = "Customer 2"}
                                                   

            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
                                                   
            //var viewResult= new ViewResult();


            return View(viewModel);

            // การส่งข้อมูลไป View 
            //viewResult.ViewData.Model = movie;
            //ViewData["Movie"] = movie;  
            //ViewBag.Movie = movie; 

            // การ return ที่สามารถเป็น Action Result ได้
            //return View();   
            //return Content("Hello World");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home",new { page = 1,sortBy = "name" });
            //return new ViewResult(); = return View()
        }

        //public ActionResult Edit(int id)
        //{
        //    return Content("id=" + id);
        //}


        // movies
        //public ActionResult Index(int? pageIndex,string sortBy)

        //{
        //    //if (!pageIndex.HasValue)
        //    //{
        //    //    pageIndex = 1;
        //    //}

        //    //if (string.IsNullOrWhiteSpace(sortBy))
        //    //{
        //    //    sortBy = "Name";
        //    //}

        //    //return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));

        //}
         
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult Index()
        {
            //var movies = GetMovies();
            //if (!movies.Any())
            //    return HttpNotFound();
            //return View(movies);

            var movies = _context.Movies.Include((m) => m.Genre).ToList();
            return View(movies);
          
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include((m)=> m.Genre).SingleOrDefault((m) => m.Id == id);
            return View(movie);

            //var movie = GetMovies().SingleOrDefault((x) => x.Id == id);
            //if (movie == null)
            //    return HttpNotFound();
            //return View(movie);
        }



        [Route("movies/Detail")]
        public ActionResult Detail()
        {
            var movie = new Movie() { Name = "hhhhh" };
            return View(movie);
        }


        // MVCRouteAttribute
        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year,int month)
        {
            return Content(year+"/"+month);
        }


        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel()
            {
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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

            if (movie.Id == 0)
            {
                movie.AddedDate = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");

        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList(),
                
            };

            return View("MovieForm", viewModel);


        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Shrek" },
                new Movie { Id = 2, Name = "Wall-e" }
            };
        }


        


    }
}