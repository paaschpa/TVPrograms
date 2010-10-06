using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TVPrograms.Core.Domain.Repository;
using TVPrograms.Core.Domain.Model;

namespace TVPrograms.Tests.Fakes
{
    public class FakeRepositoryBase<T> : IRepository<T> where T : BaseObject
    {
        public virtual List<T> itemList {get; set;}

        public virtual T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public virtual void Save(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual IList<T> GetAll()
        {
            return itemList;
        }

        public virtual void Delete(T entity)
        {
            itemList.Remove(entity);
        }

    }
}
