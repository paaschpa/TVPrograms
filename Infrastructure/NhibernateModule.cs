using System;
using System.Web;

/*
 * Who writes this stuff (not me)??? Credit goes to 'ASP.NET MVC In Action'. If I did rewrite it
 * and it's now garbage, the authors of 'ASP.NET MVC In Action' so disregard previous sentence. You know
 * what, just unread all this and there shouldn't be any issues. 
*/

namespace TVPrograms.Infrastructure
{
    public class NHibernateModule : IHttpModule
    {
        private static bool _startupComplete = false;
        private static readonly object _locker = new object();

        public void Init(HttpApplication context)
        {
            context.BeginRequest += context_BeginRequest;
            context.EndRequest += context_EndRequest;
        }

        private void context_BeginRequest(object sender, EventArgs e)
        {
            EnsureStartup();
            new DataConfig().StartSession();
        }

        private void context_EndRequest(object sender, EventArgs e)
        {
            new DataConfig().EndSession();
        }

        private void EnsureStartup()
        {
            if (!_startupComplete)
            {
                lock (_locker)
                {
                    if (!_startupComplete)
                    {
                        new DataConfig().PerformStartup();
                        _startupComplete = true;
                    }
                }
            }
        }

        public void Dispose()
        {
        }
    }
}