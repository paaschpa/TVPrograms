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
    class UserRepositoryTester
    {
        
        [Test]
        public void Should_AddOneUser()
        {
            var config = new DataConfig();
            config.PerformStartup();
            config.StartSession();

            var repository = new FakeRepository();

            User newuser = new User();
            Role newrole = new Role();
            newuser.FullName = "Test";
            newrole.RoleName = "Admin";

            newuser.Roles.Add(newrole);

            repository.Save(newuser);
            

        }

        private class FakeRepository : RepositoryBase<User>, IUserRepository
        {
            public User GetByUserName(string username)
            {
                return null;
            }
        }


    }
}