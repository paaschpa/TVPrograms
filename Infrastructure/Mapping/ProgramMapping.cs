using FluentNHibernate.Mapping;
using TVPrograms.Core.Domain.Model;

namespace TVPrograms.Infrastructure.Mapping {

public class ProgramMapping : ClassMap<Program>
{
	public ProgramMapping()
    {
        Table("Programs");
	    Id(x => x.id).GeneratedBy.Identity();

	    Map(x => x.ProgramName);

	    Map(x => x.Network_id);

	    Map(x => x.Daypart_id);

	    Map(x => x.Created_at);

	    Map(x => x.Updated_at);

        HasMany(x => x.Seasons).KeyColumn("Program_id")
        .Cascade.All();
	}
}
}
