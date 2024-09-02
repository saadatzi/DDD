using FluentResults;
namespace SSS.Application.Common.Errors;

public class DuplicateEmailError : FluentResults.IError
{
    public List<FluentResults.IError> Reasons => throw new NotImplementedException();

    public string Message => throw new NotImplementedException();

    public Dictionary<string, object> Metadata => throw new NotImplementedException();
}
