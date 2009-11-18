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
    public class EpisodeMapper : AutoFormMapper<Episode, EpisodeForm>, IEpisodeMapper
    {
        public EpisodeMapper()
        {
        }

        protected override void MapToModel(EpisodeForm form, Episode model)
        {
            model.id = form.id;
            model.Duration = form.Duration;
            model.AirDate = Convert.ToDateTime(form.AirDate);
            model.StartTime = Convert.ToDateTime(form.StartTime);
        }

        public IList<EpisodeForm> Map(IList<Episode> episodes)
        {
            return Map<IList<Episode>, IList<EpisodeForm>>(episodes);
        }
    }
}