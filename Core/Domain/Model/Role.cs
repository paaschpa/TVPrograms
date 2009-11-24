using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TVPrograms.Core.Domain.Model 
{
    public class Role : BaseObject
    {
        public virtual int id { get; set; }
        public virtual string RoleName { get; set; }
        public virtual string Description { get; set; }

        public virtual IList<User> Users { get; private set; }
 
        public Role()
        {
            Users = new List<User>();
        }

    }
}
