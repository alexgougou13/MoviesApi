using Microsoft.AspNetCore.Mvc;
using MoviesApi.Models;
using MoviesApi.MoviesData;
using System;

namespace MoviesApi.Controllers
{

    [ApiController]
    public class MoviesController : ControllerBase
    {
        private IMoviesData _movieData;
        public MoviesController(IMoviesData movieData)
        {
            _movieData = movieData;
        }
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetMovies()
        {
            return Ok(_movieData.GetMovies());
        }
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetMovie(Guid id)
        {
            var movie = _movieData.GetMovie(id);
            if (movie != null)
            {
                return Ok(_movieData.GetMovie(id));
            }
            return NotFound($"Movie with Id: {id} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddMovie(Movie movie)
        {
            _movieData.AddMovie(movie);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + movie.Id, movie);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteMovie(Guid id)
        {
            var movie = _movieData.GetMovie(id);
            if (movie != null)
            {
                _movieData.DeleteMovie(movie);
                return Ok($"The movie with Id: {id} and Title: {movie.Title} was deleted ");
            }
            return NotFound($"Movie with Id: {id} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        //EditModel same with Movie model without title Required
        //Used so user can edit a movie without havind to add title again
        public IActionResult EditMovie(Guid id,EditModel movieBody)
        {
            Movie movie = new Movie();
            movie.Id = id;
            if (movieBody.Title==null)
            {
                movieBody.Title = " ";
            }
            movie.Title = movieBody.Title;
            movie.Description = movieBody.Description;
            movie.Director = movieBody.Director;
            movie.ReleaseDate = movieBody.ReleaseDate;
            movie.ImageUrl = movieBody.ImageUrl;
            movie.Rating = movieBody.Rating;
            var ExistingMovie = _movieData.GetMovie(id);
            if (movie != null)
            {
                movie.Id = ExistingMovie.Id;
                _movieData.EditMovie(movie);
            }
            return Ok(ExistingMovie);
        }
    }
}
