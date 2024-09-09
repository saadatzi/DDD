using System.Net;

namespace SSS.Application.Common.Errors;

public interface IError
{
    public HttpStatusCode StatusCode { get; }

    public string ErrorMessage { get; }
}