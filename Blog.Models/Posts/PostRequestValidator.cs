using FluentValidation;

namespace Blog.Models.Posts
{
    public class PostRequestValidator : AbstractValidator<PostRequest>
    {
        public PostRequestValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Text.Length).LessThan(2000);
            RuleFor(x => x.Category).NotEmpty();
        }
    }
}
