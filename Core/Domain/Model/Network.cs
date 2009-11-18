using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Collections.Generic;
using TVPrograms.Core.Domain.Model.Helpers;

namespace TVPrograms.Core.Domain.Model {

    public class Network : BaseObject
    {
	
	    public virtual int id {get; set;}
	
	    public virtual string NetworkName {get; set;}
	
	    public virtual string NetworkInitials {get; set;}
	
	    public virtual DateTime Created_at {get; set;}
	
	    public virtual DateTime Updated_at {get; set;}

        public virtual IList<Program> Programs { get; set; }

        public Network()
        {
            Programs = new List<Program>();
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
