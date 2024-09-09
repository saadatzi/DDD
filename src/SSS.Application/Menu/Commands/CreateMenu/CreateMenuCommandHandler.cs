using System.Reflection;

using ErrorOr;

using MediatR;

using SSS.Contracts.Menus;

using SSS.Domain.Menu;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
    public Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        // Create Menu
        // Persist Menu
        // Return Menu
        return Task.FromResult<ErrorOr<Menu>>(default!);
    }
}