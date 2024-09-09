using SSS.Domain.Common.Models;
using SSS.Domain.Menu.ValueObjects;

namespace SSS.Domain.Menu.Entity;

public sealed class MenuItem : Entity<MenuItemId>
{
    private MenuItem(MenuItemId menuItemId, string name, string description)
    : base(menuItemId)
    {
        Name = name;
        Description = description;
    }

    public string Name { get; }

    public string Description { get; }

    public static MenuItem Create(MenuItemId menuItemId, string name, string desc) => new MenuItem(menuItemId, name, desc);
}