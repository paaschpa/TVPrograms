using TVPrograms.Core.Domain.Model;

namespace TVPrograms.Core.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ICryptographer _cryptographer;

        public AuthenticationService(ICryptographer cryptographer)
        {
            _cryptographer = cryptographer;
        }

        public bool PasswordMatches(User user, string password)
        {
            string passwordHash = _cryptographer.GetPasswordHash(password, user.PasswordSalt);
            return passwordHash.Equals(user.PasswordHash);
        }
    }
}
