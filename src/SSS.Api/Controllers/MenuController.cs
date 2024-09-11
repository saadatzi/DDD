using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using SSS.Application.Menus.Commands.CreateMenu;
using SSS.Contracts.Menus;

namespace SSS.Api.Controllers;
[Route("hosts/{hostId}/menus")]
public class MenuController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public MenuController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateMenu(
        CreateMenuRequest request,
        string hostId)
    {
        var command = _mapper.Map<CreateMenuCommand>((request, hostId));
        var createdMenuResult = await _mediator.Send(command);

        return createdMenuResult.Match(
            menu => Ok(_mapper.Map<MenuResponse>(menu)), // menu => CreatedAtAction(nameof(GetMenu), new { hostId, menuId = menu.Id }, menu), // this approach will use another get endpoint named GetMenu to make the URL
            errors => Problem(errors));
    }
}