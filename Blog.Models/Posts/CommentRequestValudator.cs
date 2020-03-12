using FluentValidation;

namespace Blog.Models.Posts
{
    public class CommentRequestValudator : AbstractValidator<CommentRequest>
    {
        public CommentRequestValudator()
        {
            RuleFor(x => x.CreatedUser).NotEmpty();
            RuleFor(x => x.PostId).NotEmpty();
            RuleFor(x => x.Text.Length).LessThan(200);
        }
    }
}
