using NHLPlayerStatistics.Interfaces;
using NHLPlayerStatistics.Services;

namespace NHLPlayerStatistics.Extensions;

public static class ServicesConfigurationExtension
{
    public static void AddNHLPlayerServices(this IServiceCollection services)
    {
        services.AddScoped<IStatisticsFetcherService, StatisticsFetcherService>();
        services.AddScoped<INHLApiService, NHLApiService>();
    }
}
