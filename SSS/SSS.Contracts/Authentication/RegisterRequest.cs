namespace SSS.Contracts.Authentication
{
    public record RegisterRequest(
        string Username,
        string Email,
        string Password
    );
}