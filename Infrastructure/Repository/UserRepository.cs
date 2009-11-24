using System.Collections.Generic;
using System.Linq;
using TVPrograms.Core.Domain.Model;
using TVPrograms.Core.Domain.Repository;
using NHibernate;

namespace TVPrograms.Infrastructure.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public User GetByUserName(string username)
        {
            ISession session = GetSession();
            IQuery query = session.CreateQuery("from Users u where u.Username = :username");
            query.SetString("username", username);

            var matchingUser = query.UniqueResult<User>();

            return matchingUser;
        }
    }
}