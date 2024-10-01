using HolidayApi.AuthDomain.Commands.Auth.CreateAccount;
using HolidayApi.Common.Models.Domains.Users.Models;

namespace HolidayApi.AuthDomain.Commands.User
{
    public interface IUserHandler
    {
        Task<IEnumerable<UserDtoModel>> GetUsersAsync();
        Task CreateUserAsync(CreateAccountRequest request);
        Task<UserDtoModel?> GetUserAsync(int id);
        Task UpdateUserAsync(UserUpdateRequest request);
        Task DeleteUserAsync(int id);
        Task<IEnumerable<UserResponse>> GetUsersWithMoreDataAsync();
    }
}
