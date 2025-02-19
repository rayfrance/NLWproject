using FluentValidation;
using TechLibrary.Comunication.Requests;

namespace TechLibrary.Api.UseCases.Users.Register
{
    public class RegisterUserValidator : AbstractValidator<RequestUserJson>
    {
        public RegisterUserValidator()
        {
            RuleFor(request => request.Name).NotEmpty().WithMessage("The name cannot be empty");
            RuleFor(request => request.Email).EmailAddress().WithMessage("Invalid e-mail");
            RuleFor(request => request.Password).NotEmpty().WithMessage("The password cannot be empty");
            When(request => string.IsNullOrEmpty(request.Password) == false, () =>
            {
                RuleFor(request => request.Password.Length).GreaterThanOrEqualTo(6).WithMessage("The password must be greater or equal than 6 characters");
            });
        }
    }
}
