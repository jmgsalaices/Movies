using Movies.Application.Common.Exceptions;
using Movies.Application.Common.Interfaces;
using Movies.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Application.Comments.Commands.UpdateComment
{
    public class UpdateCommentCommand : IRequest
    {
        public int Id { get; set; }
        
        public string User { get; set; }

        public string TextComment { get; set; }
    }

    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateCommentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Comments.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Comment), request.Id);
            }

            entity.User = request.User;
            entity.TextComment = request.TextComment;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
