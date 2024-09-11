using FluentValidation;

namespace SSS.Application.Menus.Commands.CreateMenu;

public class MenuSectionCommandValidator : AbstractValidator<MenuSectionCommand>
{
    public MenuSectionCommandValidator()
    {
        RuleFor(s => s.Name).NotEmpty();
        RuleFor(s => s.Description).NotEmpty();
        RuleForEach(s => s.Items).SetValidator(new MenuItemCommandValidator());
    }
}