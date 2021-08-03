using Movies.Application.Common.Exceptions;
using Movies.Application.Common.Interfaces;
using Movies.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Application.Comments.Commands.DeleteComment
{
    public class DeleteCommentCommand : IRequest
    {

        public int Id { get; set; }
    }

    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCommentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Comments.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Comment), request.Id);
            }

            _context.Comments.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
