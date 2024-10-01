using HolidayApi.Common.Models.Domains.HolidayRequest.Models;
using HolidayApi.Common.Models.Domains.Team.Models;
using HolidayApi.Common.Models.Domains.Users.Models;
using Mapster;

namespace HolidayApi.AuthDomain.Commands.User
{
    public class UserResponse
    {
        public UserDtoModel User { get; set; }
        public TeamDtoModel Team { get; set; }
        public HolidayRequestDtoModel HolidayRequests { get; set; }
    }

    public class UserResponseMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {


            config.NewConfig<Common.Models.Entities.User, UserResponse>()
                .Map(dest => dest.User, src => src.Adapt<UserDtoModel>())
                .Map(dest => dest.Team, src => src.Team)
                .Map(dest => dest.HolidayRequests, src => src.HolidayRequests);
            config.NewConfig<UserResponse, Common.Models.Entities.User>()
                .Map(dest => dest.Id, src => src.User.Id)
                .Map(dest => dest.FirstName, src => src.User.FirstName)
                .Map(dest => dest.LastName, src => src.User.LastName)
                .Map(dest => dest.Email, src => src.User.Email)
                .Map(dest => dest.Team, src => src.Team)
                .Map(dest => dest.HolidayRequests, src => src.HolidayRequests);
        }
    }
}
