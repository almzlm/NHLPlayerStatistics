using NHLPlayerStatistics.Extensions;

namespace NHLPlayerStatistics;

internal class Program
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        //Service Configuration
        builder.Services.AddHttpClient();
        builder.Services.AddControllers();
        builder.Services.AddNHLPlayerServices();

        //Configure request pipeline
        var app = builder.Build();
        app.MapControllers();
        app.Run();

    }
}
