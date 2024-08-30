using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SSS.Domain.Entities;

namespace SSS.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
