using HolidayApi.Common.Models;
using HolidayApi.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;

namespace HolidayApi.AuthDomain.Commands.Auth.ConfirmEmail
{
    public class ConfirmEmailHandler : IConfirmEmailHandler
    {
        private readonly HolidayApiDbContext _context;
        private readonly UserManager<Common.Models.Entities.User> _userManager;
        public ConfirmEmailHandler(HolidayApiDbContext context, UserManager<Common.Models.Entities.User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task Handle(ConfirmEmailRequest request)
        {
            request.Validate();
            var user = _context.Users.FirstOrDefault(x => x.Email == request.Email);
            if (user is not null && user.StatusId == (int)StatusEnum.Active)
            {
                if (user.EmailConfirmed)
                {
                    throw new Exception("User email is already confirmed");
                }
                else
                {
                    var result = await _userManager.ConfirmEmailAsync(user, request.Token);
                    if (!result.Succeeded)
                    {

                        throw new Exception("Something went wrong while confirming email, token might be invalid/expired");
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
