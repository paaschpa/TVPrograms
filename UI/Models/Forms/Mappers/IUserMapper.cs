using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TVPrograms.Core.Domain;
using TVPrograms.Core.Domain.Model;
using TVPrograms.UI.Models.Forms;

namespace TVPrograms.UI.Models.Forms.Mappers
{
    public interface IUserMapper : IMapper<User, UserForm>
    {
        UserForm[] Map(User[] model);
        User[] Map(UserForm[] message);
        void MapToModel1(UserForm form, User model);
    }
}