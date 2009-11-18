using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Collections.Generic;

namespace TVPrograms.UI.Models.Forms
{

    public class DaypartForm
    {

	    public virtual int id {get; set;}
	
	    public virtual string DaypartName {get; set;}
	
	    public virtual DateTime Created_at {get; set;}
	
	    public virtual DateTime Updated_at {get; set;}
    }
}
