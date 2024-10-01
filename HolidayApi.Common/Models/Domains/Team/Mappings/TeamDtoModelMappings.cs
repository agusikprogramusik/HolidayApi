using HolidayApi.Common.Models.Domains.Team.Models;
using Mapster;

namespace HolidayApi.Common.Models.Domains.Team.Mappings
{
    public class TeamDtoModelMappings : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<HolidayApi.Models.Entities.Team, TeamDtoModel>()
                .Map(src => src.TeamId, dest => dest.TeamId)
                .Map(src => src.Name, dest => dest.Name)
                .Map(src => src.Description, dest => dest.Description)
                .Map(src => src.IsActive, dest => dest.IsActive);
        }
    }
}