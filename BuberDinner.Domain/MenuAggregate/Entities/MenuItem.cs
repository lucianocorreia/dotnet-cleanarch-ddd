using BuberDinner.Domain.MenuAggregate.ValueObjects;
using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.MenuAggregate.Entities;

public sealed class MenuItem : Entity<MenuItemId>
{
    private MenuItem(MenuItemId menuItemId, string name, string description) : base(menuItemId)
    {
        Name = name;
        Description = description;
    }

    public static MenuItem Create(string name, string description)
    {
        return new MenuItem(MenuItemId.CreateUnique(), name, description);
    }

    public string Name { get; }
    public string Description { get; }
}
