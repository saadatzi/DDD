using ErrorOr;

using MediatR;

using SSS.Domain.MenuAggregate;

namespace SSS.Application.Menus.Commands.CreateMenu;

public record CreateMenuCommand(
    string HostId,
    string Name,
    string Description,
    List<MenuSectionCommand> Sections) : IRequest<ErrorOr<Menu>>;

public record MenuSectionCommand
(
    string Name,
    string Description,
    List<MenuItemCommand> Items);

public record MenuItemCommand
(
    string Name,
    string Description,
    string Price);