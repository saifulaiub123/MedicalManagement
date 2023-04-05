using FluentValidation;
using MH.Domain.Model;

namespace MH.Application.Validator
{
    public class RegisterModelValidator : AbstractValidator<RegisterModel>
    {
        public RegisterModelValidator()
        {
            //RuleFor(x => x.FullName)
            //    .NotNull()
            //    .NotEmpty()
            //    .WithMessage("Name must not be empty");
            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .WithMessage("Email must not be empty");
            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty()
                .WithMessage("Password must not be empty");
        }
    }
}
