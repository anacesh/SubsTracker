using SubsTracker.Subs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Telegram.Bot.Types;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using System.Threading;
using static Telegram.Bot.TelegramBotClient;
using Telegram.Bot.Exceptions;

namespace SubsTracker.Bot
{
    class BotManager
    {
        private readonly TelegramBotClient _bot;
        private static BotManager _instance;
        private CancellationTokenSource cts;

        public static BotManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BotManager();
                }
                return _instance;
            }
        }

        private BotManager()
        {
            cts = new CancellationTokenSource();
            _bot = new TelegramBotClient(token: BotConfig.Instance.Token, cancellationToken: cts.Token);
        }

        public async Task StartAsync()
        {
            var me = await _bot.GetMeAsync();
            Console.WriteLine($"@{me.Username} is running... Press Escape to terminate");
            ReceiverOptions _receiverOptions;
            _receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = new[]
                {
                    UpdateType.Message,
                },
            };

            _bot.StartReceiving(UpdateHandler, ErrorHandler, _receiverOptions, cts.Token);
        }

        private static async Task UpdateHandler(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            try
            {
                switch (update.Type)
                {
                    case UpdateType.Message:
                        {
                            Console.WriteLine("Pong!");
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                Logs.TrackExceptions.TrackException(ex.ToString());
            }
        }

        private static Task ErrorHandler(ITelegramBotClient botClient, Exception error, CancellationToken cancellationToken)
        {
            var ErrorMessage = error switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => error.ToString()
            };

            Logs.TrackExceptions.TrackException(ErrorMessage);
            return Task.CompletedTask;
        }

        public void StopBot()
        {
            Console.WriteLine("Bot stopped.");
        }

        public void RestartBot()
        {
            StopBot();
            StartAsync();
        }
    }
}
