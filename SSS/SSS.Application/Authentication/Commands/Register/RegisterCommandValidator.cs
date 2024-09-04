using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace SSS.Application.Authentication.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("Firstname Cannot be empty");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("LastName Cannot be empty");
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email Cannot be empty");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Password Cannot be empty");
    }
}
