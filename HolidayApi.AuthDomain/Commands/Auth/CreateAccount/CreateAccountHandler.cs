using HolidayApi.Common.Models;
using HolidayApi.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;

namespace HolidayApi.AuthDomain.Commands.Auth.CreateAccount
{
    public class CreateAccountHandler : ICreateAccountHandler
    {
        private readonly HolidayApiDbContext _context;
        private readonly UserManager<Common.Models.Entities.User> _userManager;

        public CreateAccountHandler(HolidayApiDbContext context, UserManager<Common.Models.Entities.User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task Handle(CreateAccountRequest request)
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
    }
}