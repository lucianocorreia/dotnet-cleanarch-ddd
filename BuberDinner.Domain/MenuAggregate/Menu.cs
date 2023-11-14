using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.Entities;
using BuberDinner.Domain.MenuAggregate.ValueObjects;
using BuberDinner.Domain.MenuReviewAggregate.ValueObjects;
using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.MenuAggregate;

public sealed class Menu : AggregatRoot<MenuId>
{
    private readonly List<MenuSection> sessions = [];
    private readonly List<DinnerId> dinners = [];
    private readonly List<MenuReviewId> reviews = [];

    public string Name { get; }
    public string Description { get; }
    public float AvarageRating { get; }
    public HostId HostId { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    public IReadOnlyList<MenuSection> Sessions => sessions.AsReadOnly();
    public IReadOnlyList<DinnerId> Dinners => dinners.AsReadOnly();
    public IReadOnlyList<MenuReviewId> Reviews => reviews.AsReadOnly();

    private Menu(
        MenuId menuId,
        string name,
        string description,
        float avarageRating,
        HostId hostId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(menuId)
    {
        Name = name;
        Description = description;
        AvarageRating = avarageRating;
        HostId = hostId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Menu Create(
        string name,
        string description,
        float avarageRating,
        HostId hostId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
    {
        return new(
            MenuId.CreateUnique(),
            name,
            description,
            avarageRating,
            hostId,
            createdDateTime,
            updatedDateTime);
    }


}
