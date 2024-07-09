using HolidayApi.DependencyInjection.Mapster;
using Microsoft.AspNetCore.Builder;

namespace HolidayApi.DependencyInjection.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void ConfigureCommonPipeline(this IApplicationBuilder app, bool isDevelopment, MapsterConfiguration mapster)
        {
            if (isDevelopment)
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
            }

            mapster.Scan().Compile();

            if (!isDevelopment)
                app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
