using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Collections.Generic;
using TVPrograms.Core.Domain.Model.Helpers;

namespace TVPrograms.Core.Domain.Model {

    public class Program : BaseObject
    {
	
	    public virtual int id {get; set;}
	
	    public virtual string ProgramName {get; set;}
	
	    public virtual int Network_id {get; set;}
	
	    public virtual int Daypart_id {get; set;}
	
	    public virtual DateTime Created_at {get; set;}
	
	    public virtual DateTime Updated_at {get; set;}

        public virtual Network Network { get; set; }
        public virtual IList<Season> Seasons { get; set; }

        public Program()
        {
            Seasons = new List<Season>();
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
