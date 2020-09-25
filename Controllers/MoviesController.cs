using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
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

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }


        // movies
        public ActionResult Index(int? pageIndex,string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }
            
            if (string.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));

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

    

    }
}