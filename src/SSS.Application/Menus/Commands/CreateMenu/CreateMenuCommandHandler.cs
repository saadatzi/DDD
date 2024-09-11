using ErrorOr;

using MediatR;

using SSS.Application.Common.Interfaces.Persistence;
using SSS.Application.Menus.Commands.CreateMenu;
using SSS.Domain.Common.ValueObjects;

using SSS.Domain.Host.ValueObjects;
using SSS.Domain.Menu.Entity;
using SSS.Domain.MenuAggregate;

namespace SSS.Application.Menus;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
    private readonly IMenuRepository _menuRepository;

    public CreateMenuCommandHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // Create Menu
        var menu = Menu.Create(
            name: request.Name,
            description: request.Description,
            hostId: HostId.CreateUnique(Guid.Parse(request.HostId)),
            averageRating: AverageRating.Empty(),
            sections: request.Sections.ConvertAll(
                section => MenuSection.Create(
                    name: section.Name,
                    desc: section.Description,
                    items: section.Items.ConvertAll(
                        item => MenuItem.Create(
                            item.Name,
                            item.Description,
                            float.Parse(item.Price))))));

        // Persist Menu
        _menuRepository.Add(menu);

        // Return Menu
        return menu;
    }
}