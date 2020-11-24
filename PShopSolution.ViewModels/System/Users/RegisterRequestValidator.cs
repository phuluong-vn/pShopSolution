using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PShopSolution.ViewModels.System.Users
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required.")
                .MaximumLength(200).WithMessage("First name can not over 200 characters");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("First name is required.")
                .MaximumLength(200).WithMessage("First name can not over 200 characters");

            RuleFor(x => x.Dob).GreaterThan(DateTime.Now.AddYears(-100)).WithMessage("Birthday can not greater than 100 year.");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.")
                .Matches(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$")
                .WithMessage("Email format not match.");

            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phonenumber is required.");

            RuleFor(x => x.Username).NotEmpty().WithMessage("Username is request!");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is request!")
                .MinimumLength(6).WithMessage("Password is at leat 6 character.");

            RuleFor(x => x).Custom((request, context) =>
            {
                if (request.Password != request.ConfirmPassword)
                {
                    context.AddFailure("Confirm password is not match");
                }
            });
        }
    }
}