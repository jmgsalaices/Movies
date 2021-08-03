using FluentValidation;

namespace Movies.Application.Comments.Commands.CreateComment
{
    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator()
        {
            RuleFor(v => v.User)
                .MaximumLength(200)
                .NotEmpty();

            RuleFor(v => v.TextComment)
                .MaximumLength(600)
                .NotEmpty();
        }
    }
}
