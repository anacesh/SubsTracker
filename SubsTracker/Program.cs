using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using SubsTracker.Data;
using SubsTracker.Bot;
using Microsoft.EntityFrameworkCore.Design;

namespace SubsTracker
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                            .ConfigureServices((context, services) =>
                            {
                                services.AddDbContext<AppDbContext>(options =>
                                    options.UseSqlite("Data Source=bot.db"));

                                services.AddScoped<BotManager>();
                                services.AddSingleton<BotConfig>();
                            })
                            .Build();

            using var scope = host.Services.CreateScope();
            var botManager = scope.ServiceProvider.GetRequiredService<BotManager>();

            await botManager.StartAsync();
            Console.ReadLine();
        }
    }
}
