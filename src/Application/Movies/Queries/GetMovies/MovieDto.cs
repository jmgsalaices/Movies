using System.Collections.Generic;

namespace Movies.Application.Movies.Queries.GetMovies
{
    public class MovieDto
    {
        public int Id { get; set; }

        public string Film {get; set; }

        public string Genre {get; set;}

        public string LeadStudio { get; set; }

        public int AudienceScore { get; set; }
        
        public string Profitability { get; set; }
        
        public int RottenTomatoes { get; set; }

        public string WorldwideGross {get; set; }

        public int Year { get; set; }

        public IList<CommentDto> Comments { get; private set; } = new List<CommentDto>();
    }
}