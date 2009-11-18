using AutoMapper;
using TVPrograms.Core.Domain.Model;
using TVPrograms.Core.Domain;
using TVPrograms.Core.Domain.Repository;

namespace TVPrograms.UI.Models.Forms.Mappers
{
    public abstract class AutoFormMapper<TModel, TForm> : Mapper<TModel, TForm> where TModel : BaseObject, new()
    {
        protected AutoFormMapper()
        { }

        public override K Map<T, K>(T model)
        {
            return Mapper.Map<T, K>(model);
        }
    }
}