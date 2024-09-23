using SSS.Domain.Common.Dinner.ValueObjects;
using SSS.Domain.Common.Models;
using SSS.Domain.Common.ValueObjects;
using SSS.Domain.Host.ValueObjects;
using SSS.Domain.Menu.Entity;
using SSS.Domain.Menu.ValueObjects;
using SSS.Domain.MenuAggregate.Events;
using SSS.Domain.MenuReview.ValueObjects;

namespace SSS.Domain.MenuAggregate;

/// <summary>
/// Represents a menu in the domain.
/// </summary>
public sealed class Menu : AggregateRoot<MenuId, Guid>
{
    private readonly List<MenuSection> _sections = [];

    private readonly List<DinnerId> _dinnerIds = [];
    private readonly List<MenuReviewId> _menuReviewIds = [];

    private Menu()
    {
    }

    private Menu(
        MenuId id,
        string name,
        string description,
        List<MenuSection> sections,
        HostId hostId,
        AverageRating? averageRating,
        DateTime createdDateTime,
        DateTime updateDateTime)
        : base(id)
    {
        Name = name;
        Description = description;
        _sections = sections;
        AverageRating = averageRating;
        HostId = hostId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updateDateTime;
    }

    /// <summary>
    /// Gets the sections for this menu item.
    /// </summary>
    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();

    /// <summary>
    /// Gets the dinner ids for this menu item.
    /// </summary>
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();

    /// <summary>
    /// Gets the menu review ids for this menu item.
    /// </summary>
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

    /// <summary>
    /// Gets the name of this menu item.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Gets the description of this menu item.
    /// </summary>
    public string Description { get; private set; }

    /// <summary>
    /// Gets the average rating for this menu item.
    /// </summary>
    public AverageRating? AverageRating { get; private set; }

    /// <summary>
    /// Gets the host id of this menu item.
    /// </summary>
    public HostId HostId { get; private set; }

    /// <summary>
    /// Gets the created date time for this menu item.
    /// </summary>
    public DateTime CreatedDateTime { get; private set; }

    /// <summary>
    /// Gets the updated date time for this menu item.
    /// </summary>
    public DateTime UpdatedDateTime { get; private set; }

    /// <summary>
    /// Creates a new instance of the <see cref="Menu"/> class.
    /// </summary>
    /// <param name="name">The name of the menu.</param>
    /// <param name="description">The description of the menu.</param>
    /// <param name="sections">The list of sections associated with the menu.</param>
    /// <param name="hostId">The ID of the host associated with the menu.</param>
    /// <param name="averageRating">The average rating of the menu.</param>
    /// <returns>A new instance of the <see cref="Menu"/> class.</returns>
    public static Menu Create(
        string name,
        string description,
        List<MenuSection> sections,
        HostId hostId,
        AverageRating? averageRating)
    {
        var menu = new Menu(
            MenuId.CreateUnique(),
            name,
            description,
            sections,
            hostId,
            averageRating,
            DateTime.UtcNow, // TODO: Times should instantiate in their own place not her
            DateTime.UtcNow);

        menu.AddDomainEvent(new MenuCreated(menu));

        return menu;
    }
}