using FluentNHibernate.Mapping;
using TVPrograms.Core.Domain.Model;

namespace TVPrograms.Infrastructure.Mapping
{
    public class RoleMapping : ClassMap<Role>
    {
        public RoleMapping()
        {
            Table("Roles");
	        Id(x => x.id).GeneratedBy.Identity();

	        Map(x => x.RoleName);

	        Map(x => x.Description);

	    }
    }
}
