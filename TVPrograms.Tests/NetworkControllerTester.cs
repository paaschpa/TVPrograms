using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using NUnit.Framework;
using TVPrograms.Tests.Fakes;
using TVPrograms.UI.Controllers;
using TVPrograms.Core.Domain.Model;
using TVPrograms.UI.Models.Forms;
using TVPrograms.UI.Models.Forms.Mappers;
using AutoMapper;

namespace TVPrograms.Tests
{
    [TestFixture]
    class NetworkControllerTester
    {

        NetworkController CreateNetworkController()
        {
            var testData = FakeData.CreateNetworks();
            var mapper = new FakeMapper();
            var repository = new FakeNetworkRepository(testData);

            return new NetworkController(repository, mapper);
        }

        [Test]
        public void Should_return_first_network()
        {
            var controller = CreateNetworkController();

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
                model.NetworkName = form.NetworkName;
                model.NetworkInitials = form.NetworkInitials;
            }

            public IList<NetworkForm> Map(IList<Network> networks)
            {
                return Map<IList<Network>, IList<NetworkForm>>(networks);
            }
        }

    }
}
