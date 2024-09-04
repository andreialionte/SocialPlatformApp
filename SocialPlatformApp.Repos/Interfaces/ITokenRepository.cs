namespace SocialPlatformApp.Repos.Interfaces
{
    public interface ITokenRepository
    {
        string JWTService(string userName, int userId);
    }
}
