using AutoMapper;

namespace TVPrograms.UI.Models.Forms
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x => x.AddProfile<AutoMapperProfile>());
        }
    }
}