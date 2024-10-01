using HolidayApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HolidayApi.DependencyInjection.Extensions
{
    public static class InfrastructureConfigExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<HolidayApiDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("HolidayApi"),
                    x => x.UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery));
                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
            });
        }
    }
}
