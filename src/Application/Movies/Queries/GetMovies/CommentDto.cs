using AutoMapper;
using Movies.Application.Common.Mappings;
using Movies.Domain.Entities;

namespace Movies.Application.Movies.Queries.GetMovies
{
    public class CommentDto : IMapFrom<Comment>
    {
        public int Id { get; set; }

        public MovieDto Movie { get; set; }
        
        public string User { get; set; }

        public string Comment { get; set; }
    }
}
