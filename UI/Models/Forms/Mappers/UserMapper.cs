using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TVPrograms.UI.Models.Forms;
using TVPrograms.Core.Domain.Model;
using TVPrograms.Core.Domain;
using TVPrograms.Core.Domain.Repository;
using TVPrograms.Core.Services;

namespace TVPrograms.UI.Models.Forms.Mappers
{
    public class UserMapper : AutoFormMapper<User, UserForm>, IUserMapper
    {

        private readonly ICryptographer _cryptographer;
        private readonly IUserRepository _repository;

        public UserMapper(IUserRepository repository, ICryptographer cryptographer)
        {
            _cryptographer = cryptographer;
            _repository = repository;
        }

        protected override void MapToModel(UserForm form, User model)
        {
            model.id = form.id;
            model.FullName = form.FullName;
            model.EmailAddress = form.EmailAddress;
            model.PasswordSalt = _cryptographer.CreateSalt();
            model.PasswordHash = _cryptographer.GetPasswordHash(form.Password,
                                                                model.PasswordSalt);
            model.Username = form.Username;
        }

        public UserForm[] Map(User[] model)
        {
            return model.Select(user => Map(user)).ToArray();
        }

        public User[] Map(UserForm[] message)
        {
            return message.Select(form => Map(form)).ToArray();
        }

        public User Map(UserForm message)
        {
            User model = _repository.GetById(message.id);
            MapToModel(message, model);
            return model;
        }
    }
}