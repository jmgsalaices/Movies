using System;
using Movies.Domain.Common;
using Movies.Domain.ValueObjects;
using System.Collections.Generic;

namespace Movies.Domain.Entities

{
    public class Movie
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

        public IList<Comment> Comments { get; private set; } = new List<Comment>();
    }
}