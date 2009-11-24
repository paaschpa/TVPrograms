using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using NUnit.Framework;
using AutoMapper;
using TVPrograms.Infrastructure.Repository;
using TVPrograms.UI.Controllers;
using TVPrograms.UI.Models.Forms;
using TVPrograms.UI.Models.Forms.Mappers;
using TVPrograms.Core.Domain.Repository;
using TVPrograms.Core.Domain;
using TVPrograms.Core.Domain.Model;
using TVPrograms.Infrastructure;

namespace TVPrograms.Tests
{
    [TestFixture]
    class NetworkControllerTester
    {
        [Test]
        public void Should_return_first_network()
        {
            var config = new DataConfig();
            config.PerformStartup();
            config.StartSession();
            
            var repository = new FakeRepository();
            var mapper = new FakeMapper();
            var controller = new NetworkController(repository, mapper);

            var viewresult = controller.List() as ViewResult;
            var model = (Network)viewresult.ViewData.Model;
            Assert.That(model.NetworkName, Is.EqualTo("Fox")); 
        }

        private class FakeMapper : AutoFormMapper<Network, NetworkForm>, INetworkMapper
        {
            public FakeMapper()
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

        private class FakeRepository : RepositoryBase<Network>, INetworkRepository
        {

        }   


    }
}
