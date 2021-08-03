using Movies.Application.Common.Exceptions;
using Movies.Application.Common.Interfaces;
using Movies.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Application.Movies.Commands.DeleteMovie
{
    public class DeleteMovieCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteMpvieCommandHandler : IRequestHandler<DeleteMovieCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteMpvieCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Movies
                .Where(l => l.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Movie), request.Id);
            }

            _context.Movies.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
