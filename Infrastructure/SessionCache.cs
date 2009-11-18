using System.Collections;
using System.Web;
using NHibernate;
using System.Web;

/*
 * The code below does something pretty important. No, I don't know what it does.  Quit bothering me
 * and just ask somebody with glasses and pocket protector. You don't see anyone resembling that...how 
 * about a calculator watch...No...then just find an ugly person. 
*/


namespace TVPrograms.Infrastructure
{
    public class SessionCache
    {
        private const string SESSION_KEY = "NHIBERNATE_SESSION";
        private static readonly IDictionary _cacheStore = new Hashtable();

        public ISession GetSession()
        {
            var session = (ISession)GetCacheStore()[SESSION_KEY];
            return session;
        }

        public void CacheSession(ISession session)
        {
            GetCacheStore()[SESSION_KEY] = session;
        }

        private static IDictionary GetCacheStore()
        {
            if (HttpContext.Current != null)
                return HttpContext.Current.Items;

            return _cacheStore;
        }
    }
}