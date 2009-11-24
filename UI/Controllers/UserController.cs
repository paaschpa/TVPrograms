using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using TVPrograms.Core.Domain.Model;
using TVPrograms.Core.Domain.Repository;
using TVPrograms.Core.Domain;
using TVPrograms.UI.Models.Forms;
using TVPrograms.UI.Models.Forms.Mappers;
using TVPrograms.Core.Services;


namespace UI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserMapper _userMapper;
        private readonly IUserSession _session;

        public UserController(IUserRepository repository, IUserMapper mapper, IUserSession session) 
        {
            _userRepository = repository;
            _userMapper = mapper;
            _session = session;
        }

        public ViewResult Edit(User user)
        {
            if (user == null)
            {
                return View(_userMapper.Map(_session.GetCurrentUser()));
            }

            UserForm form = _userMapper.Map(user);
            return View(form);
        }

    }
}
