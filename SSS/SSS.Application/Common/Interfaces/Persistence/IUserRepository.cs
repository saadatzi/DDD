using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SSS.Domain.Entities;

namespace SSS.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
   User? GetUserByEmail(string email);
   void AddUser(User user);
}
