using Movies.Application.Common.Exceptions;
using Movies.Application.Common.Interfaces;
using Movies.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Application.Movies.Commands.UpdateMovie
{
    public class UpdateMovieCommand : IRequest
    {
        public int Id { get; set; }

        public string Film {get; set; }

        public string Genre {get; set;}

        public string LeadStudio { get; set; }  

        public int AudienceScore { get; set; }
        
        public string Profitability { get; set; }

        public int RottenTomatoes {get; set;}

        public string WorldwideGross {get; set; }

        public int Year { get; set; }
    }

    public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateMovieCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Movies.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Movie), request.Id);
            }

            entity.Film = request.Film;
            entity.Genre = request.Genre;
            entity.LeadStudio = request.LeadStudio;
            entity.AudienceScore = request.AudienceScore;
            entity.Profitability = request.Profitability;
            entity.RottenTomatoes = request.RottenTomatoes;
            entity.WorldwideGross = request.WorldwideGross;
            entity.Year = request.Year;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
