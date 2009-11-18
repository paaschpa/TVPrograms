using FluentNHibernate.Mapping;
using TVPrograms.Core.Domain.Model;

namespace TVPrograms.Infrastructure.Mapping {

public class DaypartMapping : ClassMap<Daypart>
{
	public DaypartMapping()
    {
        Table("Dayparts");
	    Id(x => x.id).GeneratedBy.Identity();

	    Map(x => x.DaypartName);

	    Map(x => x.Created_at);

	    Map(x => x.Updated_at);
	}
}
}
