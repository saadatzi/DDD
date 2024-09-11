using FluentValidation;

namespace SSS.Application.Menus.Commands.CreateMenu;

public class MenuItemCommandValidator : AbstractValidator<MenuItemCommand>
{
    public MenuItemCommandValidator()
    {
        RuleFor(i => i.Name).NotEmpty();
        RuleFor(i => i.Description).NotEmpty();
        RuleFor(i => i.Price)
            .Must(BeValidFloat)
            .WithMessage("The Provided value is not valid float.");
    }

    private bool BeValidFloat(string price)
    {
        return float.TryParse(price, out _);
    }
}