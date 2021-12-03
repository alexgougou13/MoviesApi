using MoviesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApi.MoviesData
{
    public class SqlMovieData : IMoviesData
    {
        private MovieContext _movieContext;
        public SqlMovieData(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }
        public Movie AddMovie(Movie movie)
        {
            movie.Id = Guid.NewGuid();
            _movieContext.Movies.Add(movie);
            _movieContext.SaveChanges();
            return movie;
        }

        public void DeleteMovie(Movie movie)
        {
            _movieContext.Movies.Remove(movie);
            _movieContext.SaveChanges();
        }

        public Movie EditMovie(Movie movie)
        {
            //checking if values are given from body so we won't pass null as value
            //if values not given we keep the existing ones
            var existingMovie = _movieContext.Movies.Find(movie.Id);
            if (movie.Title==" ")
            {
                movie.Title = existingMovie.Title;
            }
            
            if (existingMovie.Title != movie.Title )
            {
                existingMovie.Title = movie.Title;
            }
            if (existingMovie.Description != movie.Description && movie.Description!=null)
            {
                existingMovie.Description = movie.Description;
            }
            if (existingMovie.ReleaseDate != movie.ReleaseDate && movie.ReleaseDate.Date.ToString("yyyy")!="0001")
            {
                existingMovie.ReleaseDate = movie.ReleaseDate;
            }
            if (existingMovie.ImageUrl != movie.ImageUrl && movie.ImageUrl != null)
            {
                existingMovie.ImageUrl = movie.ImageUrl;
            }
            if (existingMovie.Rating != movie.Rating && movie.Rating != 0)
            {
                existingMovie.Rating = movie.Rating;
            }
            if (existingMovie.Director != movie.Director && movie.Director!=null)
            {
                existingMovie.Director = movie.Director;
            }
            _movieContext.Movies.Update(existingMovie);
            _movieContext.SaveChanges();
            return existingMovie;
        }

        public Movie GetMovie(Guid id)
        {
            var movie = _movieContext.Movies.Find(id);
            return movie;
        }

        public List<Movie> GetMovies()
        {
           return _movieContext.Movies.ToList();
        }
    }
}
