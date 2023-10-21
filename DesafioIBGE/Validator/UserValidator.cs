using DesafioIBGE.Model;
using FluentValidation;

namespace DesafioIBGE.Validator;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(u => u.usuario)
            .NotEmpty()
            .MaximumLength(255)
            .EmailAddress();

        RuleFor(u => u.senha)
            .NotEmpty()
            .MinimumLength(8)
            .MaximumLength(255);
    }
}