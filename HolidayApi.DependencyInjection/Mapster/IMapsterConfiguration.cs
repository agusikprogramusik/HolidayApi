namespace HolidayApi.DependencyInjection.Mapster
{
    public interface IMapsterConfiguration
    {
        MapsterConfiguration Scan();
        MapsterConfiguration Compile();
    }
}