using HolidayApi.Common.Models;
using HolidayApi.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;

namespace HolidayApi.AuthDomain.Commands.Auth.GenerateConfirmEmail
{
    public class GenerateConfirmEmailHandler : IGenerateConfirmEmailHandler
    {
        private readonly HolidayApiDbContext _context;
        private readonly UserManager<Common.Models.Entities.User> _userManager;
        public GenerateConfirmEmailHandler(HolidayApiDbContext context, UserManager<Common.Models.Entities.User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task Handle(GenerateConfirmEmailRequest request)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == request.Email);
            if (user is not null && user.StatusId == (int)StatusEnum.Active)
            {
                if (user.EmailConfirmed)
                {
                    throw new Exception("User email is already confirmed");
                }
                else
                {
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    if (token is not null)
                    {
                        Console.WriteLine($"Generate email confirmation token for user {user.UserName}: " + token);
                    }

                }
            }
            else
            {

                throw new Exception("User does not exist");

            }
        }
    }
}
