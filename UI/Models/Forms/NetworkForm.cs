using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Collections.Generic;
using TVPrograms.Core.Domain.Model;

namespace TVPrograms.UI.Models.Forms {

    public class NetworkForm
    {
	
	    public virtual int id {get; set;}
	
	    public virtual string NetworkName {get; set;}
	
	    public virtual string NetworkInitials {get; set;}
	
	    public virtual DateTime Created_at {get; set;}
	
	    public virtual DateTime Updated_at {get; set;}

        public virtual IList<ProgramForm> Programs { get; set; }

    }
}
