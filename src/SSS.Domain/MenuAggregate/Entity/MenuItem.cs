using SSS.Domain.Common.Models;
using SSS.Domain.Menu.ValueObjects;

namespace SSS.Domain.Menu.Entity;

public sealed class MenuItem : Entity<MenuItemId>
{
    private MenuItem(MenuItemId itemId, string name, string description, float price)
    : base(itemId)
    {
        Name = name;
        Description = description;
        Price = price;
    }

    public string Name { get; }

    public string Description { get; }

    public float Price { get; }

    public static MenuItem Create(
        string name,
        string desc,
        float price) => new MenuItem(
            MenuItemId.CreateUnique(),
            name,
            desc,
            price);
}