using Mapster;

using SSS.Contracts.Menus;
using SSS.Domain.Host.ValueObjects;

namespace SSS.Api.Common.Mapping;

public class MenuMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateMenuRequest Request, string HostId), CreateMenuCommand>()
            .Map(dest => dest.HostId, src => src.HostId)
            .Map(dest => dest, src => src.Request); // rest of the src (CreateMenuRequest) map to CreateMenuCommand
    }
}