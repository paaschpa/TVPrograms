using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TVPrograms.Core.Domain.Model;

namespace TVPrograms.Core.Domain
{
    public interface IMapper<TModel, TMessage> where TModel : BaseObject, new()
    {
        TMessage Map(TModel model);
        TMessage2 Map<TMessage2>(TModel model);
        //TModel Map(TMessage message);
    }
}