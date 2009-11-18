using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TVPrograms.Core.Domain.Model;

namespace TVPrograms.Core.Domain.Repository
{
    public interface IRepository<T> where T : BaseObject
    {
        T GetById(int id);
        void Save(T entity);
        IList<T> GetAll();
        void Delete(T entity);
    }

}
