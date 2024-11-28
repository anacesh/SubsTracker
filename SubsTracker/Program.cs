using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using SubsTracker.Data;
using SubsTracker.Bot;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace SubsTracker
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                            .ConfigureServices((context, services) =>
                            {
                                services.AddDbContext<AppDbContext>((options) =>
                                {
                                    options.UseSqlite("Data Source=bot.db");
                                    options.UseLoggerFactory(LoggerFactory.
                                        Create(builder => builder.
                                            AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Warning)));
                                });

                                services.AddSingleton<BotManager>();
                                services.AddSingleton<BotConfig>();
                            })
                            .Build();

            using var scope = host.Services.CreateScope();
            var botManager = scope.ServiceProvider.GetRequiredService<BotManager>();

            await botManager.StartAsync();

            while (true)
                Console.ReadLine();
        }
    }
}
