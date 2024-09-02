using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SSS.Application.Common.Errors;

public class DuplicateEmailException(string message) : Exception(message), IServiceException
{
    private readonly string _errorMessage = message;

    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

    public string ErrorMessage => _errorMessage;
}
