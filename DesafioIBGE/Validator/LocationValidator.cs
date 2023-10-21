using System.Reflection.Metadata.Ecma335;
using DesafioIBGE.Model;
using FluentValidation;

namespace DesafioIBGE.Validator;

public class LocationValidator : AbstractValidator<Location>
{
    public LocationValidator()
    {
        RuleFor(L => L.id)
            .NotEmpty().Length(7);


        RuleFor(L => L.state)
            .NotEmpty().Length(2);
           
        
        RuleFor(L => L.city)
            .NotEmpty()
            .MaximumLength(80);
    }
}