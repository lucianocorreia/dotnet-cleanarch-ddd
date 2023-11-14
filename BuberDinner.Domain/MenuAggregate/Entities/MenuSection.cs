using BuberDinner.Domain.MenuAggregate.ValueObjects;
using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.MenuAggregate.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> items = [];

    public string Name { get; }
    public string Description { get; }

    public IReadOnlyList<MenuItem> Items => items.AsReadOnly();

    private MenuSection(MenuSectionId menuSectionId, string name, string description) : base(menuSectionId)
    {
        Name = name;
        Description = description;
    }

    public static MenuSection Create(string name, string description)
    {
        return new MenuSection(MenuSectionId.CreateUnique(), name, description);
    }

}
