using FluentNHibernate.Mapping;
using TVPrograms.Core.Domain.Model;

namespace TVPrograms.Infrastructure.Mapping
{
   public class UserMapping : ClassMap<User>
    {

        public UserMapping()
        {
            Table("Users");
	        Id(x => x.id).GeneratedBy.Identity();

	        Map(x => x.Username);

	        Map(x => x.FullName);

	        Map(x => x.EmailAddress);

            Map(x => x.PasswordHash);

            Map(x => x.PasswordSalt);

            HasManyToMany(x => x.Roles)
             .Cascade.All()
             .Table("UserInRoles");

	    }
    }
}
