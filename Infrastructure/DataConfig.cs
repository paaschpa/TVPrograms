﻿using System;
using System.IO;
using log4net.Config;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Automapping;

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

        private void InitializeNHibernateSessionFactory()
        {
            var fluentConfig = Fluently.Configure()
            .Database(MsSqlConfiguration.MsSql2005.ConnectionString(x =>
                x.FromConnectionStringWithKey("ConnectionString")
            ).Cache(c => c
            .UseQueryCache())
            .ShowSql()).
            Mappings(m => 
                {
                    m.FluentMappings.AddFromAssemblyOf<Mapping.DaypartMapping>();
                    m.FluentMappings.AddFromAssemblyOf<Mapping.EpisodeMapping>();
                    m.FluentMappings.AddFromAssemblyOf<Mapping.EpisodeTweetMapping>();
                    m.FluentMappings.AddFromAssemblyOf<Mapping.NetworkMapping>();
                    m.FluentMappings.AddFromAssemblyOf<Mapping.ProgramMapping>();
                    m.FluentMappings.AddFromAssemblyOf<Mapping.SeasonMapping>();
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