using Telegram.Bot;

namespace TomarMedicacion.Services
{
    public class TelegramService
    {
        private readonly TelegramBotClient _bot;
        public TelegramService(IConfiguration configuration)
        {
            var token =
                configuration["Telegram:BotToken"];

            _bot = new TelegramBotClient(token);
        }

        public async Task SendMessageAsync(
            long chatId,
            string message)
        {
            await _bot.SendMessage(
                chatId: chatId,
                text: message);
        }
    }
}
