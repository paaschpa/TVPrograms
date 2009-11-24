using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TVPrograms.Core.Domain.Model.Helpers;

namespace TVPrograms.Core.Domain.Model
{
    public class User : BaseObject
    {
        public virtual int id { get; set; }
        public virtual string Username { get; set; }
        public virtual string FullName { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual string PasswordSalt { get; set; }
        public virtual IList<Role> Roles { get; set; }
        
        public User()
        {
            Roles = new List<Role>();
        }

        public override int GetHashCode()
        {
            return HashCodeGenerator.GenerateHashCode(id);
        }
        public override bool Equals(object obj)
        {
            return this.IsEqual(obj);
        }
    }
}
