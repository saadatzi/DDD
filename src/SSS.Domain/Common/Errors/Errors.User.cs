using ErrorOr;

namespace SSS.Domain.Common.Errors;
public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail => Error.Conflict(
            code: "User.DuplicateEmail",
            description: "This email has been already used.");
    }
}