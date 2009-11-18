using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Collections.Generic;
using TVPrograms.Core.Domain.Model.Helpers;


namespace TVPrograms.Core.Domain.Model {

    public class Season : BaseObject
    {
	    public virtual int id {get; set;}
	
	    public virtual double SeasonNumber {get; set;}
	
	    public virtual DateTime StartDate {get; set;}
	
	    public virtual DateTime EndDate {get; set;}
	
	    public virtual int Program_id {get; set;}
	
	    public virtual DateTime Created_at {get; set;}
	
	    public virtual DateTime Updated_at {get; set;}

        public virtual Program Program { get; set; }
                
        public virtual IList<Episode> Episodes { get; set; }

        public Season()
        {
            Episodes = new List<Episode>();
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
