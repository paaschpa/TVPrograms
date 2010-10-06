using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap;
using TVPrograms.Infrastructure.Repository;
using TVPrograms.Core.Domain.Repository;
using StructureMap.Graph;

namespace TVPrograms.UI
{

    public class BootStrapper
    {

        public static void ConfigureStructureMap()
        {
            ObjectFactory.Initialize(ConfigStructureMap);
        }

        private static void ConfigStructureMap(IInitializationExpression x)
        {
            x.AddRegistry(new ServiceRegistry());
        }

        public class ServiceRegistry : StructureMap.Configuration.DSL.Registry
        {
            
            protected override void configure()
            {
               //ForRequestedType<INetworkRepository>().TheDefaultIsConcreteType<NetworkRepository>();
               //ForRequestedType<IProgramRepository>().TheDefaultIsConcreteType<ProgramRepository>();
                Scan(x =>
                {
                    x.Assembly("Infrastructure");
                    x.Assembly("UI");
                    x.Assembly("Core");
                    x.With<DefaultConventionScanner>();
                    x.LookForRegistries();
                });

                ForRequestedType(typeof(IRepository<>)).TheDefaultIsConcreteType(typeof(RepositoryBase<>));
            }
        }
    }

}

