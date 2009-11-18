using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TVPrograms.UI.Models.Forms;
using TVPrograms.Core.Domain.Model;
using TVPrograms.Core.Domain;
using TVPrograms.Core.Domain.Repository;

namespace TVPrograms.UI.Models.Forms.Mappers
{
    public class ProgramMapper : AutoFormMapper<Program, ProgramForm>, IProgramMapper
    {
        public ProgramMapper()
        {
        }

        protected override void MapToModel(ProgramForm form, Program model)
        {
            model.id = form.id;
            //model.Network = (Network)form.Network;
            model.Network_id = form.Network_id;
        }

        public IList<ProgramForm> Map(IList<Program> programs)
        {
            return Map<IList<Program>, IList<ProgramForm>>(programs);
        }
    }
}