using Mapster;

using SSS.Application.Menus.Commands.CreateMenu;

using SSS.Contracts.Menus;
using SSS.Domain.Host.ValueObjects;
using SSS.Domain.Menu.Entity;
using SSS.Domain.MenuAggregate;

namespace SSS.Api.Common.Mapping;

public class MenuMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateMenuRequest Request, string HostId), CreateMenuCommand>()
            .Map(dest => dest.HostId, src => src.HostId)
            .Map(dest => dest, src => src.Request); // rest of the src (CreateMenuRequest) map to CreateMenuCommand

        config.NewConfig<Menu, MenuResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.HostId, src => src.HostId.Value)
            .Map(dest => dest.DinnerIds, src => src.DinnerIds.Select(d => d.Value))
            .Map(dest => dest.MenuReviewIds, src => src.MenuReviewIds.Select(d => d.Value))
            .Map(dest => dest.AverageReting, src => src.AverageRating!.Value);

        config.NewConfig<MenuSection, MenuSectionResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);

        config.NewConfig<MenuItem, MenuItemResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);
    }
}