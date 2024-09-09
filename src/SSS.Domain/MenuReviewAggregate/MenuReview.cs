using SSS.Domain.Common.Models;
using SSS.Domain.MenuReview.ValueObjects;

namespace SSS.Domain.MenuReview;

public class MenuReview : AggregateRoot<MenuReviewId>
{
    private MenuReview(MenuReviewId id, string name)
        : base(id)
    {
        Name = name;
    }

    public string Name { get; }

    public static MenuReview Create(MenuReviewId id, string name) => new MenuReview(id, name);
}