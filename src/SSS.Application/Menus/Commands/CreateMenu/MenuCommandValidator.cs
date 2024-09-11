using FluentValidation;

namespace SSS.Application.Menus.Commands.CreateMenu;

public class MenuCommandValidator : AbstractValidator<CreateMenuCommand>
{
    public MenuCommandValidator()
    {
        RuleFor(m => m.Name).NotEmpty();
        RuleFor(m => m.HostId).NotEmpty();
        RuleFor(m => m.Description).NotEmpty();
        RuleForEach(m => m.Sections).SetValidator(new MenuSectionCommandValidator());
    }
}