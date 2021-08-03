using Movies.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Application.Movies.Commands.CreateMovie
{
    public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateMovieCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Film)
                .NotEmpty().WithMessage("Name Film is required.")
                .MaximumLength(200).WithMessage("Film must not exceed 200 characters.")
                .MustAsync(BeUniqueTitle).WithMessage("The specified title already exists.");
        }

        public async Task<bool> BeUniqueTitle(string title, CancellationToken cancellationToken)
        {
            return await _context.Movies
                .AllAsync(l => l.Film != title);
        }
    }
}
