using FluentValidation;

namespace PShopSolution.ViewModels.System
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username is request!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is request!")
                .MinimumLength(6).WithMessage("Password is at leat 6 character.");
        }
    }
}