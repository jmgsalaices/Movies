using System.Collections.Generic;

namespace Movies.Application.Movies.Queries.GetMovies
{
    public class MoviesVm
    {
        public IList<MovieDto> Movies { get; set; }
    }
}
