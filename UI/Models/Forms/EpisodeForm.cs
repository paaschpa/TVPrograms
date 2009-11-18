using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Collections.Generic;

namespace TVPrograms.UI.Models.Forms {

public class EpisodeForm
{
	
	public virtual int id {get; set;}
	
	public virtual string EpisodeName {get; set;}
	
	public virtual string AirDate {get; set;}

    public virtual string StartTime { get; set; }

    public virtual float Duration { get; set; }

    public virtual float HHLD_Proj { get; set; }
	
	public virtual int Season_id {get; set;}

	public virtual DateTime Created_at {get; set;}
	
	public virtual DateTime Updated_at {get; set;}

}
}
