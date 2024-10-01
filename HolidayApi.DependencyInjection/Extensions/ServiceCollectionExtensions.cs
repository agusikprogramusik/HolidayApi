using HolidayApi.AuthDomain.Commands.Auth.AccountLogin;
using HolidayApi.AuthDomain.Commands.Auth.ConfirmEmail;
using HolidayApi.AuthDomain.Commands.Auth.CreateAccount;
using HolidayApi.AuthDomain.Commands.Auth.GenerateConfirmEmail;
using HolidayApi.AuthDomain.Commands.User;
using HolidayApi.Common.Models.Entities;
using HolidayApi.Infrastructure.Persistence;
using HolidayApi.TokenService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HolidayApi.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureCommonServices(this IServiceCollection service, IConfiguration configuration, string projectName)
        {
            service.AddIdentity<User, UserRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = false;
            })
            .AddEntityFrameworkStores<HolidayApiDbContext>()
            .AddDefaultTokenProviders();
            service.AddAuthorization();
            service.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("igufadigafdioadfigaiaougfodgog36543651686180953068jgfdfgkkafdkjdfab"))
                };
            });

            service.AddTransient<ICreateAccountHandler, CreateAccountHandler>();
            service.AddTransient<IGenerateConfirmEmailHandler, GenerateConfirmEmailHandler>();
            service.AddTransient<IConfirmEmailHandler, ConfirmEmailHandler>();
            service.AddTransient<IJwtTokenService, JwtTokenService>();
            service.AddTransient<IAccountLoginHandler, AccountLoginHandler>();
            service.AddTransient<IUserHandler, UserHandler>();

            service.AddMapster();
            service.AddControllers();
            service.AddEndpointsApiExplorer();
            service.AddSwagger(projectName);
            service.AddInfrastructure(configuration);
        }
    }
}