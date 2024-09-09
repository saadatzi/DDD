using SSS.Domain.Common.Models;
using SSS.Domain.Menu.ValueObjects;

namespace SSS.Domain.Menu.Entity;

public sealed class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _menuItems = [];

    private MenuSection(MenuSectionId id, string name, string description)
        : base(id)
    {
        Name = name;
        Description = description;
    }

    public IReadOnlyList<MenuItem> MenuItems => _menuItems.AsReadOnly();

    public string Name { get; }

    public string Description { get; }

    public static MenuSection Create(MenuSectionId id, string name, string desc) => new MenuSection(id, name, desc);
}