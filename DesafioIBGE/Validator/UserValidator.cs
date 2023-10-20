using DesafioIBGE.Model;
using FluentValidation;

namespace DesafioIBGE.Validator;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(u => u.Usuario)
            .NotEmpty()
            .MaximumLength(255)
            .EmailAddress();

        RuleFor(u => u.Senha)
            .NotEmpty()
            .MinimumLength(8)
            .MaximumLength(32);
    }
}