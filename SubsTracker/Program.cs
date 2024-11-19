using Microsoft.Extensions.Configuration;
using SubsTracker.Bot;

namespace SubsTracker.Bot
{
    class Program
    {
        static void Main(string[] args)
        {
            var botConfig = BotConfig.Instance;
            Console.WriteLine($"Token: {botConfig.Token}");


        }
    }
}