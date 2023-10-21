using System.Reflection.Metadata.Ecma335;
using DesafioIBGE.Model;
using FluentValidation;

namespace DesafioIBGE.Validator;

public class LocationValidator : AbstractValidator<Location>
{
    public LocationValidator()
    {
        RuleFor(L => L.Id)
            .NotEmpty().Length(7);


        RuleFor(L => L.State)
            .NotEmpty().Length(2);
           
        
        RuleFor(L => L.City)
            .NotEmpty()
            .MaximumLength(80);
    }
}