using System;
using TVPrograms.Core.Domain.Model;
using TVPrograms.Core.Domain.Repository;

namespace TVPrograms.Core.Domain
{
    public abstract class Mapper<TModel, TMessage> : IMapper<TModel, TMessage> where TModel : BaseObject, new()
    {

        public abstract K Map<T, K>(T model);

        public virtual TMessage Map(TModel model)
        {
            return Map<TMessage>(model);
        }

        public TMessage2 Map<TMessage2>(TModel model)
        {
            return Map<TModel, TMessage2>(model);
        }

        protected abstract void MapToModel(TMessage message, TModel model);

    }
}
