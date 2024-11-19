using Microsoft.Extensions.Configuration;
using SubsTracker.Bot;

namespace SubsTracker
{
    class Program
    {
        static async Task Main(string[] args)
        {
            BotConfig botConfig = BotConfig.Instance;
            BotManager botManager = BotManager.Instance;
            await botManager.StartAsync();
            Console.ReadLine();
        }
    }
}