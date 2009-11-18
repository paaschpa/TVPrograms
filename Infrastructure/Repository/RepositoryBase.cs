using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TVPrograms.Core.Domain.Repository;
using TVPrograms.Core.Domain.Model;
using NHibernate;

namespace TVPrograms.Infrastructure.Repository
{
    public class RepositoryBase<T> : IRepository<T> where T : BaseObject
    {

        public virtual T GetById(int id)
        {
            ISession session = GetSession();
            return session.Get<T>(id);
        }

        public virtual void Save(T entity)
        {
            using (ISession session = GetSession())
            using (ITransaction tx = session.BeginTransaction())
            {
                session.SaveOrUpdate(entity);
                tx.Commit();
            }
        }

        public virtual IList<T> GetAll()
        {
            ISession session = GetSession();
            ICriteria criteria = session.CreateCriteria(typeof(T));
            return criteria.List<T>().ToArray();
        }

        public virtual void Delete(T entity)
        {
            using (ISession session = GetSession())
            using (ITransaction tx = session.BeginTransaction())
            {
                session.Delete(entity);
                tx.Commit();
            }
        }

        protected ISession GetSession()
        {
            //Retrieves a session from our own cache
            var cache = new SessionCache();
            ISession session = cache.GetSession();
            return session;
        }
    }
}

