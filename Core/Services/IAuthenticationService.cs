using TVPrograms.Core.Domain.Model;

namespace TVPrograms.Core.Services
{
    public interface IAuthenticationService
    {
        bool PasswordMatches(User user, string password);
    }
}
