using FluentValidation;

namespace Movies.Application.Comments.Commands.UpdateComment
{
    public class UpdateCommentCommandValidator : AbstractValidator<UpdateCommentCommand>
    {
        public UpdateCommentCommandValidator()
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
