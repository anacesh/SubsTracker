using Microsoft.Extensions.Configuration;
using System;
using System.Xml;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

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
            const string configFileName = "appsettings.json";

            if (!File.Exists(configFileName))
            {
                Console.WriteLine("The appsettings.json file was not found.");
                Console.Write("Please enter the token for the Telegram Bot: ");
                string userToken = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(userToken))
                {
                    Console.WriteLine("Error: The token cannot be empty!");
                    Environment.Exit(1);
                }

                var appSettings = new
                {
                    TelegramBot = new
                    {
                        Token = userToken
                    }
                };

                File.WriteAllText(configFileName, JsonConvert.SerializeObject(appSettings, Newtonsoft.Json.Formatting.Indented));

                Console.WriteLine($"The file {configFileName} has been successfully created.");
                Token = userToken;
            }
            else
            {
                var configuration = new ConfigurationBuilder()
                    .AddJsonFile(configFileName, optional: false, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .Build();

                configuration.GetSection("TelegramBot").Bind(this);
            }

            if (string.IsNullOrEmpty(Token))
            {
                Console.WriteLine("Error: Token not found in appsettings.json.");
                Environment.Exit(1);
            }
        }
    }
}