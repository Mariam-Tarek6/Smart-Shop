namespace WebApplication19
{
    public interface IJwtTokenManager
    {
        (string accessToken, string refreshToken) Authenticate(string Email, string password);
    }
}
