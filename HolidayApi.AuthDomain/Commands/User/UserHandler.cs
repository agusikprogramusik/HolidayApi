using HolidayApi.AuthDomain.Commands.Auth.CreateAccount;
using HolidayApi.Common.Models;
using HolidayApi.Common.Models.Domains.Users.Models;
using HolidayApi.Infrastructure.Persistence;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace HolidayApi.AuthDomain.Commands.User
{
    public class UserHandler : IUserHandler
    {
        private readonly HolidayApiDbContext _context;
        private readonly UserManager<Common.Models.Entities.User> _userManager;

        public UserHandler(HolidayApiDbContext context, UserManager<Common.Models.Entities.User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IEnumerable<UserDtoModel>> GetUsersAsync()
        {
            var users = await _context.Users.Where(x => x.StatusId == (int)StatusEnum.Active).ToListAsync();
            return users.Select(x => x.Adapt<UserDtoModel>());
        }

        public async Task CreateUserAsync(CreateAccountRequest request)
        {
            request.Validate();
            var user = _context.Users.FirstOrDefault(x => x.Email == request.Email);
            if (user is not null && user.StatusId == (int)StatusEnum.Active)
            {
                if (user.EmailConfirmed)
                {
                    throw new Exception("User already exists");
                }
                else
                {
                    throw new Exception("User already exists, but email is not confirmed");
                }

            }
            else
            {
                Common.Models.Entities.User newUser = new Common.Models.Entities.User
                {
                    Email = request.Email,
                    UserName = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    DateOfBirth = request.DateOfBirth,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    StatusId = (int)StatusEnum.Active,
                    RoleId = (int)UserRolesEnum.User,

                };
                var result = await _userManager.CreateAsync(newUser, request.Password);
                if (!result.Succeeded)
                {
                    throw new Exception("Something went wrong while creating user");
                }

            }
        }

        public async Task<UserDtoModel?> GetUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user is not null && user.StatusId == (int)StatusEnum.Active)
            {
                return user.Adapt<UserDtoModel>();
            }
            throw new Exception("User not found");
        }

        public async Task UpdateUserAsync(UserUpdateRequest request)
        {
            request.Validate();
            var userToUpdate = await _context.Users.FindAsync(request.Id);
            if (userToUpdate is null || userToUpdate.StatusId == (int)StatusEnum.Deleted)
                throw new Exception("User not found");
            userToUpdate.FirstName = request.FirstName;
            userToUpdate.LastName = request.LastName;
            userToUpdate.Email = request.Email;
            _context.Users.Update(userToUpdate);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = _context.Users.Find(id);
            if (user is null || user.StatusId == (int)StatusEnum.Deleted)
                throw new Exception("User not found");
            user.StatusId = (int)StatusEnum.Deleted;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserResponse>> GetUsersWithMoreDataAsync()
        {
            var users = await _context.Users
                .Where(x => x.StatusId == (int)StatusEnum.Active)
                .Include(x => x.Team)
                .Include(x => x.HolidayRequests)
                .ToListAsync();
            List<UserResponse> userResponses = new List<UserResponse>();

            foreach (Common.Models.Entities.User user in users)
            {

                userResponses.Add(user.Adapt<UserResponse>());

            }
            return userResponses.AsEnumerable();
        }
    }
}
