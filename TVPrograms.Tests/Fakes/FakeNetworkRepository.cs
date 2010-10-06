using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TVPrograms.Core.Domain.Repository;
using TVPrograms.Core.Domain.Model;


namespace TVPrograms.Tests.Fakes
{
    public class FakeNetworkRepository : FakeRepositoryBase<Network>, INetworkRepository
    {

        public FakeNetworkRepository(List<Network> networks)
        {
            itemList = networks;
        }

        public override Network GetById(int id)
        {
            return itemList.SingleOrDefault(x => x.id == id);
        }
    }
}
