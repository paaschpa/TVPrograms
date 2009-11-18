using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TVPrograms.Core.Domain;
using TVPrograms.Core.Domain.Model;
using TVPrograms.UI.Models.Forms;

namespace TVPrograms.UI.Models.Forms.Mappers
{
    public interface IEpisodeMapper : IMapper<Episode, EpisodeForm>
    {
        IList<EpisodeForm> Map(IList<Episode> episodes);
    }
}