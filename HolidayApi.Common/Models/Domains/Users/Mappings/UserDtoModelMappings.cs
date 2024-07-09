using HolidayApi.Common.Models.Domains.Users.Models;
using HolidayApi.Common.Models.Entities;
using Mapster;

namespace HolidayApi.Common.Models.Domains.Users.Mappings;

public class UserDtoModelMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<User, UserDtoModel>()
            .Map(src => src.Id, dest => dest.Id)
            .Map(src => src.FirstName, dest => dest.FirstName)
            .Map(src => src.LastName, dest => dest.LastName)
            .Map(src => src.Email, dest => dest.Email);
    }
}

