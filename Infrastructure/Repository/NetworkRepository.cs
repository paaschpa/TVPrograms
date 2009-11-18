using System.Collections.Generic;
using System.Linq;
using TVPrograms.Core.Domain.Model;
using TVPrograms.Core.Domain.Repository;
using NHibernate;

namespace TVPrograms.Infrastructure.Repository
{
    public class NetworkRepository : RepositoryBase<Network>, INetworkRepository
    {

    }
}
