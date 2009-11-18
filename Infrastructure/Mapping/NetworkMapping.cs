using FluentNHibernate.Mapping;
using TVPrograms.Core.Domain.Model;

namespace TVPrograms.Infrastructure.Mapping {

public class NetworkMapping : ClassMap<Network>
{
	public NetworkMapping()
    {
        Table("Networks");
	    Id(x => x.id).GeneratedBy.Identity();

	    Map(x => x.NetworkName);

	    Map(x => x.NetworkInitials);

	    Map(x => x.Created_at);

	    Map(x => x.Updated_at);

        HasMany(x => x.Programs).KeyColumn("Network_id")
        .Cascade.All();
	}
}
}
