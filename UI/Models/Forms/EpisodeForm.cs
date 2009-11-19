using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Collections.Generic;

namespace TVPrograms.UI.Models.Forms {

public class EpisodeForm
{
    private string _starttime = DateTime.Now.ToString();
    private string _airdate = DateTime.Now.ToString();

	public virtual int id {get; set;}
	
	public virtual string EpisodeName {get; set;}

    public virtual string AirDate
    {
        get { return _airdate; }
        set { _airdate = Convert.ToDateTime(value).ToShortDateString(); }
    }

    public string AirDateDay
    {
        get { return Convert.ToDateTime(AirDate).ToString("ddd"); }
        set { ;}
    }

    public virtual string StartTime
    {
        get { return _starttime; }
        set{_starttime = Convert.ToDateTime(value).ToString("t");}
    }

    public virtual float Duration { get; set; }

    public virtual float HHLD_Proj { get; set; }
	
	public virtual int Season_id {get; set;}

	public virtual DateTime Created_at {get; set;}
	
	public virtual DateTime Updated_at {get; set;}

}
}
