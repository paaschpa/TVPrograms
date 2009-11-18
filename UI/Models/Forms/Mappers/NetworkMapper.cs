using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TVPrograms.UI.Models.Forms;
using TVPrograms.Core.Domain.Model;
using TVPrograms.Core.Domain;
using TVPrograms.Core.Domain.Repository;

namespace TVPrograms.UI.Models.Forms.Mappers
{
    public class NetworkMapper : AutoFormMapper<Network, NetworkForm>, INetworkMapper
    {
        public NetworkMapper()
        {
        }


        protected override void MapToModel(NetworkForm form, Network model)
        {
            model.id = form.id;
            model.NetworkName= form.NetworkName;
            model.NetworkInitials = form.NetworkInitials;
        }

        public IList<NetworkForm> Map(IList<Network> networks)
        {
            return Map<IList<Network>, IList<NetworkForm>>(networks);
        }
    }
}