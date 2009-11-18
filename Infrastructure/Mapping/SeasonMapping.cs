using FluentNHibernate.Mapping;
using TVPrograms.Core.Domain.Model;

namespace TVPrograms.Infrastructure.Mapping {


public class SeasonMapping : ClassMap<Season>
{
	public SeasonMapping()
    {
        Table("Seasons");
	    Id(x => x.id).GeneratedBy.Identity();

	    Map(x => x.SeasonNumber);

	    Map(x => x.StartDate);

	    Map(x => x.EndDate);

	    Map(x => x.Program_id);

	    Map(x => x.Created_at);

	    Map(x => x.Updated_at);

        HasMany(x => x.Episodes).KeyColumn("Season_id")
        .Cascade.All();

    }
}
}
