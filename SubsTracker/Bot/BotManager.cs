using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using SubsTracker.Data;
using Microsoft.EntityFrameworkCore;
using SubsTracker.Tracker;

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
            var me = await _bot.GetMe();
            TrackExceptions.SendBotMessage($"@{me.Username} is running... Press Enter to terminate");

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

                    TrackExceptions.SendDebugMessage($"Received message: {update.Message.Text}", "new_message");


                    var existringUser = await _dbContext.Users.FirstOrDefaultAsync
                        (u => u.Id == fromUser.Id.ToString(),
                        cancellationToken);

                    TrackExceptions.SendDebugMessage("username: " + update.Message.From.FirstName, "new_message");

                    if (existringUser == null)
                    {
                        TrackExceptions.SendDebugMessage("new User", "new_user");
                        var user = new Users.User(
                            username: update.Message.From.FirstName ?? "User",
                            id: update.Message.From.Id.ToString()
                        );

                        _dbContext.Users.Add(user);
                        await _dbContext.SaveChangesAsync(cancellationToken);

                        existringUser = user;
                    }
                    else if (existringUser.UserName != update.Message.From.FirstName)
                    {
                        existringUser.UserName = update.Message.From.FirstName;
                        await _dbContext.SaveChangesAsync(cancellationToken);
                        TrackExceptions.SendDebugMessage("Новое имя пользователя", "user_info");
                    }
                    
                    TrackExceptions.SendDebugMessage($"username: {existringUser.UserName}," +
                        $" id: {existringUser.Id}," +
                        $" state: {existringUser.State}","user_info");

                    await botClient.SendMessage(
                        chatId: update.Message.Chat.Id,
                        text: $"Hello, {existringUser.UserName ?? "User"}! Your account was successfully created.",
                        cancellationToken: cancellationToken
                    );
                }
            }
            catch (Exception ex)
            {
                TrackExceptions.TrackException(ex.Message);
            }
        }

        private Task ErrorHandler(ITelegramBotClient botClient, Exception error, CancellationToken cancellationToken)
        {
            TrackExceptions.TrackException(error.Message);
            return Task.CompletedTask;
        }

        public void StopBot()
        {
            _cts.Cancel();
            TrackExceptions.TrackException("Bot stopped.");
        }
    }
}
