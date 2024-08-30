using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SSS.Application.Common.Interfaces.Persistence;
using SSS.Domain.Entities;

namespace SSS.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _user = [];

    public void AddUser(User user)
    {
        _user.Add(user);
    }

    public User? GetUserByEmail(string email) => _user.SingleOrDefault(x => x.Email == email);
}
