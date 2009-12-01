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

        public ViewResult Create()
        {
            return View(new UserForm());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(UserForm form)
        {
            if (ModelState.IsValid)
            {
                //mapping from conferenceform to conference
                User user = new User();
                _userMapper.MapToModel1(form, user);

                //saving the conference with the repository
                _userRepository.Save(user);
                form = _userMapper.Map(user);
                return View(form);
            }

            return View(form);
        }



        public ActionResult Edit(int id)
        {
            UserForm form = _userMapper.Map(_userRepository.GetById(id));

            return View(form);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(UserForm form)
        {
            if (ModelState.IsValid)
            {
                //mapping from conferenceform to conference
                User user = new User();
                _userMapper.MapToModel1(form, user);

                //saving the conference with the repository
                _userRepository.Save(user);
                form = _userMapper.Map(user);
                return View(form);
            }

            return View(form);
        }
    }
}
