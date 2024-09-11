using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SSS.Application.Common.Interfaces.Persistence;
using SSS.Domain.MenuAggregate;

namespace SSS.Infrastructure.Persistence;

public class MenuRepository : IMenuRepository
{
    private static readonly List<Menu> _menus = [];

    public void Add(Menu menu)
    {
        _menus.Add(menu);
    }
}