using Movies.Application.Common.Interfaces;
using Movies.Domain.Entities;
using Movies.Domain.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Application.Comments.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest<int>
    {
        public int MovieId { get; set; }
        
        public string User { get; set; }

        public string TextComment { get; set; }
    }

    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateCommentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var entity = new Comment
            {
                User = request.User,
                TextComment = request.TextComment
            };

            _context.Comments.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
