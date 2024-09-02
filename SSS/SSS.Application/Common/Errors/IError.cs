using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SSS.Application.Common.Errors;

public interface IError
{
    public HttpStatusCode StatusCode{ get; }
    public string ErrorMessage{ get; }
}
