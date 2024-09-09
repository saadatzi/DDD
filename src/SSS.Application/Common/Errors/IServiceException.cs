using System.Net;

namespace SSS.Application.Common.Errors;

public interface IServiceException
{
    public HttpStatusCode StatusCode { get; }

    public string ErrorMessage { get; }
}