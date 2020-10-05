using AutoMapper;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding.Binders;
using Vidly.Dtos;
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


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET api/movies
        [HttpGet]
        public IHttpActionResult GetMovies(string query = null)
        {

            var moviesQuery = _context.Movies
                .Include(m => m.Genre)
                .Where(m=> m.NumberAvailable > 0);


            if (!String.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery
                    .Where(m => m.Name.Contains(query));

            var moviesDto = moviesQuery
                .ToList().Select(Mapper.Map<Movie, MovieDto>);


                

            //var movies =  _context.Movies
            //    .Include(m => m.Genre)
            //    .ToList()
            //    .Select(Mapper.Map<Movie,MovieDto>);
            return Ok(moviesDto);
        }

        // GET api/movies/id

        [HttpGet]
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

           return  Ok(Mapper.Map<Movie,MovieDto>(movie));
        }

        // POST api/movies
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovie)]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            movie.AddedDate = DateTime.Now; 
            _context.Movies.Add(movie);

            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto) ;
        }

        // PUT api/movies/id
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovie)]
        public IHttpActionResult UpdateMovie(int id,MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                return NotFound();

            Mapper.Map(movieDto, movieInDb);

            _context.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }


        // DELETE api/movies/id
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovie) ]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                return NotFound();

            _context.Movies.Remove(movieInDb);

            _context.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);

        }



    }
}
