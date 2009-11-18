using System;
using System.Collections.Generic;
using AutoMapper;
using TVPrograms.Core.Domain.Model;

namespace TVPrograms.UI.Models.Forms
{
    public class AutoMapperProfile : Profile
    {
        public const string VIEW_MODEL = "TVPrograms";

        protected override string ProfileName
        {
            get { return VIEW_MODEL; }
        }

        protected override void Configure()
        {
            CreateMaps();
        }

        private static void CreateMaps()
        {
            Mapper.CreateMap<Network, NetworkForm>();
            Mapper.CreateMap<Program, ProgramForm>();
            Mapper.CreateMap<Season, SeasonForm>();
            Mapper.CreateMap<Episode, EpisodeForm>();
        }
    }
}