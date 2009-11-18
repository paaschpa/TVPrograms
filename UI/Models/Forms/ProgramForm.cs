using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Collections.Generic;
using TVPrograms.Core.Domain.Model;

namespace TVPrograms.UI.Models.Forms {

    public class ProgramForm
    {
	
	    public virtual int id {get; set;}
	
	    public virtual string ProgramName {get; set;}
	
	    public virtual int Network_id {get; set;}
	
	    public virtual int Daypart_id {get; set;}
	
	    public virtual DateTime Created_at {get; set;}
	
	    public virtual DateTime Updated_at {get; set;}

        public virtual Network Network { get; set; }

        public virtual IList<SeasonForm> Seasons { get; set; }

    }
}
