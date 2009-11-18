using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Collections.Generic;
using TVPrograms.Core.Domain.Model.Helpers;

namespace TVPrograms.Core.Domain.Model {

public class Episode : BaseObject
{


	
	public virtual int id {get; set;}
	
	public virtual string EpisodeName {get; set;}
	
	public virtual DateTime AirDate {get; set;}

    public virtual DateTime StartTime { get; set; }

    public virtual float Duration { get; set; }

    public virtual float HHLD_Proj { get; set; }
	
	public virtual int Season_id {get; set;}

	public virtual DateTime Created_at {get; set;}
	
	public virtual DateTime Updated_at {get; set;}

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
