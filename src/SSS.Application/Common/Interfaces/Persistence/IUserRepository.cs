using SSS.Domain.Entities;

namespace SSS.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
   User? GetUserByEmail(string email);

   void AddUser(User user);
}