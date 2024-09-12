using SSS.Domain.Common.Models;
using SSS.Domain.Menu.ValueObjects;

namespace SSS.Domain.Menu.Entity;

public sealed class MenuItem : Entity<MenuItemId>
{
    private MenuItem()
    {
    }

    private MenuItem(MenuItemId itemId, string name, string description, float price)
    : base(itemId)
    {
        Name = name;
        Description = description;
        Price = price;
    }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public float Price { get; private set; }

    public static MenuItem Create(
        string name,
        string desc,
        float price) => new MenuItem(
            MenuItemId.CreateUnique(),
            name,
            desc,
            price);
}