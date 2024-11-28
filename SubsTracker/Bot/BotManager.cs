using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Exceptions;
using SubsTracker.Data;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;

namespace SubsTracker.Bot
{
    class BotManager
    {
        private readonly TelegramBotClient _bot;
        private readonly AppDbContext _dbContext;
        private readonly CancellationTokenSource _cts;

        public BotManager(AppDbContext dbContext, BotConfig botConfig)
        {
            _dbContext = dbContext;
            _cts = new CancellationTokenSource();
            _bot = new TelegramBotClient(token: botConfig.Token, cancellationToken: _cts.Token);
        }

        public async Task StartAsync()
        {
            var me = await _bot.GetMeAsync();
            Console.WriteLine($"@{me.Username} is running... Press Enter to terminate");

            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = Array.Empty<UpdateType>(),
            };

            _bot.StartReceiving(UpdateHandler, ErrorHandler, receiverOptions, _cts.Token);
        }

        private async Task UpdateHandler(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            try
            {
                if (update.Type == UpdateType.Message && update.Message?.Text != null)
                {
                    var fromUser = update.Message.From;
                    if (fromUser == null) return;

                    //Console.WriteLine($"Received message: {update.Message.Text}");

                    var existringUser = await _dbContext.Users.FirstOrDefaultAsync
                        (u => u.Id == fromUser.Id.ToString(),
                        cancellationToken);

                    Console.WriteLine("username: " + update.Message.From.Username);

                    if (existringUser == null)
                    {
                        Console.WriteLine("Новый пользователь!");
                        var user = new Users.User(
                            username: update.Message.From.Username ?? "User",
                            id: update.Message.From.Id.ToString()
                        );

                        _dbContext.Users.Add(user);
                        await _dbContext.SaveChangesAsync(cancellationToken);
                    }

                    await botClient.SendTextMessageAsync(
                        chatId: update.Message.Chat.Id,
                        text: $"Hello, @{fromUser.Username ?? "User"}! Your account was successfully created.",
                        cancellationToken: cancellationToken
                    );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
            }
        }

        private Task ErrorHandler(ITelegramBotClient botClient, Exception error, CancellationToken cancellationToken)
        {
            Console.WriteLine($"An error occurred: {error.Message}");
            return Task.CompletedTask;
        }

        public void StopBot()
        {
            _cts.Cancel();
            Console.WriteLine("Bot stopped.");
        }
    }
}
