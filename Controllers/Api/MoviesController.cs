using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding.Binders;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }


        // GET api/movies
        [HttpGet]
        public IEnumerable< Movie> GetMovies()
        {
            return _context.Movies.ToList();
        }

        // GET api/movies/id

        [HttpGet]
        public Movie GetMovie(int id)
        {
            var customer = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return customer;
        }

        // POST api/movies
        [HttpPost]
        public Movie CreateMovie(Movie movie)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);



            movie.AddedDate = DateTime.Now;
            _context.Movies.Add(movie);

            _context.SaveChanges();

            return movie;
        }

        // PUT api/movies/id
        [HttpPut]
        public void UpdateMovie(int id,Movie movie)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            movieInDb.Name = movie.Name;
            movieInDb.GenreId = movie.GenreId;
            movieInDb.NumberInStock = movie.NumberInStock;
            movieInDb.ReleaseDate = movie.ReleaseDate;

        }


    }
}
