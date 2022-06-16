using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSerwisRowerowy.Models
{
    public class RegisterUserValidation : AbstractValidator<RegisterUserModel>
    {
        public RegisterUserValidation(ApplicationDbContext dbContext)
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .MinimumLength(6);

            RuleFor(x => x.ConfirmPassword)
                .Equal(y => y.Password);

            RuleFor(x => x.Email)
                .Custom((value, context) =>
                {
                    var temp = dbContext.Users.Any(u => u.Email == value);
                    if (temp)
                    {
                        context.AddFailure("Email", "That email is taken");
                    }
                });

        }
    }
}
