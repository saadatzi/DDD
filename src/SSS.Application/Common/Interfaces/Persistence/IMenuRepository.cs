using SSS.Domain.MenuAggregate;

namespace SSS.Application.Common.Interfaces.Persistence;

public interface IMenuRepository
{
    void Add(Menu menu);
}