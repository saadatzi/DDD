using SSS.Domain.Common.Models;
using SSS.Domain.Menu.ValueObjects;

namespace SSS.Domain.Menu.Entity;

public sealed class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _items = [];

    private MenuSection(MenuSectionId id, string name, string description, List<MenuItem> items)
        : base(id)
    {
        Name = name;
        Description = description;
        _items = items;
    }

    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

    public string Name { get; }

    public string Description { get; }

    public static MenuSection Create(
        string name,
        string desc,
        List<MenuItem> items) => new MenuSection(
            MenuSectionId.CreateUnique(),
            name,
            desc,
            items);
}