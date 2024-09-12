using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SSS.Application.Common.Interfaces.Persistence;
using SSS.Domain.MenuAggregate;

namespace SSS.Infrastructure.Persistence;

public class MenuRepository : IMenuRepository
{
    private readonly SSSDBContext _dbContext;

    public MenuRepository(SSSDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Menu menu)
    {
        _dbContext.Add(menu);
        _dbContext.SaveChanges();
    }
}