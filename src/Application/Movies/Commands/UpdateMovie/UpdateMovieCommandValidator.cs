using Movies.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Application.Movies.Commands.UpdateMovie
{
    public class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateMovieCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Film)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(200).WithMessage("Title must not exceed 200 characters.")
                .MustAsync(BeUniqueTitle).WithMessage("The specified title already exists.");
        }

        public async Task<bool> BeUniqueTitle(UpdateMovieCommand model, string title, CancellationToken cancellationToken)
        {
            return await _context.Movies
                .Where(l => l.Id != model.Id)
                .AllAsync(l => l.Film != title);
        }
    }
}
