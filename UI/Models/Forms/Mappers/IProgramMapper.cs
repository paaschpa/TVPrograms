using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TVPrograms.Core.Domain;
using TVPrograms.Core.Domain.Model;
using TVPrograms.UI.Models.Forms;

namespace TVPrograms.UI.Models.Forms.Mappers
{
    public interface IProgramMapper : IMapper<Program, ProgramForm>
    {
        IList<ProgramForm> Map(IList<Program> programs);
    }
}