using TVPrograms.Core.Domain.Model;

namespace TVPrograms.Core.Services
{
    public interface IUserSession
    {
        User GetCurrentUser();
        void LogIn(User user);
        void LogOut();
    }
}
