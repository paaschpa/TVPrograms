using FluentNHibernate.Mapping;
using TVPrograms.Core.Domain.Model;

namespace TVPrograms.Infrastructure.Mapping {

public class EpisodeTweetMapping : ClassMap<EpisodeTweet>
{
	public EpisodeTweetMapping()
    {
        Table("EpisodeTweets");
	    Id(x => x.id).GeneratedBy.Identity();

	    Map(x => x.TweetText);

	    Map(x => x.Episode_id);

	    Map(x => x.Created_at);

	    Map(x => x.Updated_at);

	}
}
}
