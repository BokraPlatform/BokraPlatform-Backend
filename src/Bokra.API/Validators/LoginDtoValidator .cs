using Bokra.API.DTOs.Auth.Response;
using FluentValidation;

namespace Bokra.API.Validators
{
    public class LoginDtoValidator : AbstractValidator<LoginDtos>
    {
        public LoginDtoValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email format");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters");
        }
    }
}
