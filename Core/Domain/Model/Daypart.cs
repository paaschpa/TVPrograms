
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Collections.Generic;
using TVPrograms.Core.Domain.Model.Helpers;

namespace TVPrograms.Core.Domain.Model {

public class Daypart : BaseObject
{

	public virtual int id {get; set;}
	
	public virtual string DaypartName {get; set;}
	
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
