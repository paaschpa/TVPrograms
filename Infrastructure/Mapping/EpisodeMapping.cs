using FluentNHibernate.Mapping;
using TVPrograms.Core.Domain.Model;

namespace TVPrograms.Infrastructure.Mapping {

public class EpisodeMapping : ClassMap<Episode>
{
	public EpisodeMapping()
    {
        Table("Episodes");
	    Id(x => x.id).GeneratedBy.Identity();

	    Map(x => x.EpisodeName);

	    Map(x => x.AirDate);

        Map(x => x.StartTime);

        Map(x => x.Duration);

        Map(x => x.HHLD_Proj);

	    Map(x => x.Season_id);

	    Map(x => x.Created_at);

	    Map(x => x.Updated_at);

	}
}
}
