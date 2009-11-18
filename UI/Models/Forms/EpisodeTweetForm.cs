using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Collections.Generic;

namespace TVPrograms.UI.Models.Forms {

public class EpisodeTweetForm
{

	public virtual int id {get; set;}
	
	public virtual string TweetText {get; set;}
	
	public virtual int Episode_id {get; set;}
	
	public virtual DateTime Created_at {get; set;}
	
	public virtual DateTime Updated_at {get; set;}

}
}
