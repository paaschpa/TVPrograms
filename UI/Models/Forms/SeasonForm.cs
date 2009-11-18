using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Collections.Generic;
using TVPrograms.Core.Domain.Model;

namespace TVPrograms.UI.Models.Forms {

    public class SeasonForm
    {
	    public virtual int id {get; set;}
	
	    public virtual double SeasonNumber {get; set;}
	
	    public virtual DateTime StartDate {get; set;}
	
	    public virtual DateTime EndDate {get; set;}
	
	    public virtual int Program_id {get; set;}
	
	    public virtual DateTime Created_at {get; set;}
	
	    public virtual DateTime Updated_at {get; set;}

        public virtual Program Program { get; set; }
                
        public virtual IList<EpisodeForm> Episodes { get; set; }

    }
}
