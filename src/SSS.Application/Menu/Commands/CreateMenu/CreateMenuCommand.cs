using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ErrorOr;

using MediatR;

using SSS.Domain.Menu;

namespace SSS.Contracts.Menus;

public record CreateMenuCommand(
    string HostId,
    string Name,
    string Description,
    List<MenuSectionCommand> Sections) : IRequest<ErrorOr<Menu>>;

public record MenuSectionCommand
(
    string Name,
    string Description,
    List<MenuItemCommand> MenuItems
);

public record MenuItemCommand
(
    string Name,
    string Description
);