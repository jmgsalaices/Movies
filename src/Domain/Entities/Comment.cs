
namespace Movies.Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }

        public Movie Movie { get; set; }

        public int MovieId { get; set; }
        
        public string User { get; set; }

        public string TextComment { get; set; }
        
    }
}