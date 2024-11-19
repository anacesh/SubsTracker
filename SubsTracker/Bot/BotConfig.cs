using Microsoft.Extensions.Configuration;
using System;

namespace SubsTracker.Bot
{
    public class BotConfig
    {
        public string Token { get; set; }

        private static BotConfig _instance;
        private BotConfig() { }

        public static BotConfig Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BotConfig();
                    _instance.LoadConfig();
                }
                return _instance;
            }
        }

        private void LoadConfig()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            configuration.GetSection("TelegramBot").Bind(this);

            if (!File.Exists("appsettings.json"))
            {
               Logs.TrackExceptions.TrackException("Appsettings.json не найден");
            }
        }
    }
}
