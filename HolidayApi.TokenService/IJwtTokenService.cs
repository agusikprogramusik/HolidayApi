using HolidayApi.Common.Models.Entities;

namespace HolidayApi.TokenService
{
    public interface IJwtTokenService
    {
        Task<AuthToken> Handle(User user);
    }
}