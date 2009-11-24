using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TVPrograms.Core.Domain.Model;

namespace TVPrograms.Core.Domain.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByUserName(string username);
    }
}
