using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSS.Infrastructure.Authentication;

public class JwtSetting
{
    public const string SectionName = "JwtSettings";
    public string Secret { get; init;} = null!;
    public int ExpiryMinutes { get; init;}
    public string Issure { get; init;} = null!;
    public string Audience { get; init;} = null!;
    
}
