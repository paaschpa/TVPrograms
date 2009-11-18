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
    public class SeasonMapper : AutoFormMapper<Season, SeasonForm>, ISeasonMapper
    {
        public SeasonMapper()
        {
        }

        protected override void MapToModel(SeasonForm form, Season model)
        {
            model.id = form.id;
            //model.Network = (Network)form.Network;
            model.Program_id = form.Program_id;
        }

        public SeasonForm[] Map(Season[] seasons)
        {
            return Map<Season[], SeasonForm[]>(seasons);
        }
    }
}