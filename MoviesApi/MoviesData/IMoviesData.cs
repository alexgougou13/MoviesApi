using System;
using MoviesApi.Models;
using System.Collections.Generic;

namespace MoviesApi.MoviesData
{
    public interface IMoviesData
    {
        List<Movie> GetMovies();
        Movie GetMovie(Guid id);
        Movie AddMovie(Movie movie);
        void DeleteMovie(Movie movie);
        Movie EditMovie(Movie movie);
    }
}
