using System;
using Movies.Application.Common.Interfaces;
using Movies.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Application.Movies.Commands.CreateMovie
{
    public class CreateMovieCommand : IRequest<int>
    {
        public string Film {get; set; }

        public string Genre {get; set;}

        public string LeadStudio { get; set; }

        public int AudienceScore { get; set; }
        
        public string Profitability { get; set; }

        public int RottenTomatoes { get; set; }

        public string WorldwideGross {get; set; }

        public int Year { get; set; }
    }

    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateMovieCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var entity = new Movie();

            entity.Film = request.Film;
            entity.Genre = request.Genre;
            entity.LeadStudio = request.LeadStudio;
            entity.AudienceScore = request.AudienceScore;
            entity.Profitability = request.Profitability;
            entity.RottenTomatoes = request.RottenTomatoes;
            entity.WorldwideGross = request.WorldwideGross;
            entity.Year = request.Year;

            _context.Movies.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
