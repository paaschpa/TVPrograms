using System;
using System.IO;
using log4net.Config;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Automapping;

/*
 * The stuff below works because I didn't write it. Most is hijacked from the book
 * ASP.NET MVC In Action - Chapter 13.3 Nhibernate is for getting ladies 
 * Also, the files NhibernateModule.cs and SessionCache.cs are related to this and 
 * come from the book as well. Generally, I don't read books, but the guy on the cover is 
 * very dapper and surely has ladies foraging about for him.
*/

namespace TVPrograms.Infrastructure
{
    public class DataConfig
    {
        public static ISessionFactory SessionFactory;

        public void PerformStartup()
        {
            InitializeLog4Net();
            InitializeNHibernateSessionFactory();
        }

        private void InitializeLog4Net()
        {
            //Initialize log4net from the config file.
            string configPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Log4Net.config");
            var fileInfo = new FileInfo(configPath);
            XmlConfigurator.ConfigureAndWatch(fileInfo);
        }

        //x.FromConnectionStringWithKey("ConnectionString")
        private void InitializeNHibernateSessionFactory()
        {
            var fluentConfig = Fluently.Configure()
            .Database(MsSqlConfiguration.MsSql2005.ConnectionString(x =>
                x.Server("PC2CE944D9ZT").Database("TVPrograms").TrustedConnection()
            ).Cache(c => c
            .UseQueryCache())
            .ShowSql()).
            Mappings(m => 
                {
                    m.FluentMappings.AddFromAssemblyOf<Mapping.DaypartMapping>();
                });
            var nhibConfig = fluentConfig.BuildConfiguration();
            SessionFactory = nhibConfig.BuildSessionFactory();

        }

        public void StartSession()
        {
            //The session factory provides the session
            ISession session = SessionFactory.OpenSession();

            //In this context, we will use on transaction per 
            //web request
            session.BeginTransaction();
            var cache = new SessionCache();
            cache.CacheSession(session);
        }

        public void EndSession()
        {
            var cache = new SessionCache();
            ISession session = cache.GetSession();

            //Commit the transaction if it has not been
            //rolled back.
            ITransaction transaction = session.Transaction;
            if (transaction.IsActive)
            {
                transaction.Commit();
            }

            session.Dispose();
        }
    }
}
