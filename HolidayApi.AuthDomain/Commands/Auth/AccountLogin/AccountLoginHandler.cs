using HolidayApi.Common.Models;
using HolidayApi.Infrastructure.Persistence;
using HolidayApi.TokenService;
using Microsoft.AspNetCore.Identity;

namespace HolidayApi.AuthDomain.Commands.Auth.AccountLogin
{
    public class AccountLoginHandler : IAccountLoginHandler
    {
        private readonly HolidayApiDbContext _context;
        private readonly UserManager<Common.Models.Entities.User> _userManager;

        public AccountLoginHandler(HolidayApiDbContext context, UserManager<Common.Models.Entities.User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<AccountLoginResponse> Handle(AccountLoginRequest request)
        {
            request.Validate();
            var user = _context.Users.FirstOrDefault(x => x.Email == request.Email);
            if (user is not null && user.StatusId == (int)StatusEnum.Active)
            {
                if (user.EmailConfirmed)
                {
                    var result = _userManager.CheckPasswordAsync(user, request.Password);
                    if (result.Result)
                    {
                        Console.WriteLine($"User {user.UserName} logged in");
                        JwtTokenService jwtTokenService = new JwtTokenService();
                        AuthToken token = await jwtTokenService.Handle(user);
                        Console.WriteLine($"User {user.UserName} token: " + token.Token);
                        return new()
                        {
                            Token = token.Token,
                            Expires = token.Expires
                        };
                    }
                    else
                    {
                        throw new Exception("Wrong password");
                    }
                }
                else
                {
                    throw new Exception("User email is not confirmed");
                }
            }
            else
            {
                throw new Exception("User does not exist");
            }
        }
    }
}
