using SSS.Domain.Common.Dinner.ValueObjects;
using SSS.Domain.Common.Models;
using SSS.Domain.Host.ValueObjects;
using SSS.Domain.Menu.Entity;
using SSS.Domain.Menu.ValueObjects;
using SSS.Domain.MenuReview.ValueObjects;

namespace SSS.Domain.Menu;

/// <summary>
/// Represents a menu in the domain.
/// </summary>
public sealed class Menu : AggregateRoot<MenuId>
{
    private readonly List<MenuSection> _sections = [];

    private readonly List<DinnerId> _dinnerIds = [];
    private readonly List<MenuReviewId> _menuReviewIds = [];

    private Menu(
        MenuId id,
        string name,
        string description,
        float averageRating,
        HostId hostId,
        DateTime createdDateTime,
        DateTime updateDateTime)
        : base(id)
    {
        this.Name = name;
        this.Description = description;
        this.AverageRating = averageRating;
        this.HostId = hostId;
        this.CreatedDateTime = createdDateTime;
        this.UpdatedDateTime = updateDateTime;
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
    public string Name { get; }

    /// <summary>
    /// Gets the description of this menu item.
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// Gets the average rating for this menu item.
    /// </summary>
    public float AverageRating { get; }

    /// <summary>
    /// Gets the host id of this menu item.
    /// </summary>
    public HostId HostId { get; }

    /// <summary>
    /// Gets the created date time for this menu item.
    /// </summary>
    public DateTime CreatedDateTime { get; }

    /// <summary>
    /// Gets the updated date time for this menu item.
    /// </summary>
    public DateTime UpdatedDateTime { get; }

    /// <summary>
    /// Creates a new instance of the <see cref="Menu"/> class.
    /// </summary>
    /// <param name="name">The name of the menu.</param>
    /// <param name="description">The description of the menu.</param>
    /// <param name="averageRating">The average rating of the menu.</param>
    /// <param name="hostId">The ID of the host associated with the menu.</param>
    /// <returns>A new instance of the <see cref="Menu"/> class.</returns>
    public static Menu Create(
        string name,
        string description,
        float averageRating,
        HostId hostId) => new Menu(
            MenuId.CreateUnique(),
            name,
            description,
            averageRating,
            hostId,
            DateTime.UtcNow,
            DateTime.UtcNow);
}