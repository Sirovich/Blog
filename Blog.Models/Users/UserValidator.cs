using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;


namespace Blog.Models.Users
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Id).Custom((x, context) =>
            {
                if (!int.TryParse(x, out int value))
                {
                    context.AddFailure($"{x} is not a valid number");
                }
            });

            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Password).MinimumLength(5);
            RuleFor(x => x.UserName).MinimumLength(5);
        }
    }
}
