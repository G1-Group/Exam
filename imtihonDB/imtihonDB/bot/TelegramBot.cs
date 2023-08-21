using System;
using System.Threading;
using System.Threading.Tasks;
using imtihonDB.auth;
using imtihonDB.Configurations;
using imtihonDB.service;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace imtihonDB.bot
{
    public class TelegramBot
    {
        Auth _auth;
        private bool? NewLog;
        private bool? NewPassword;
        private string? log;

        
        public  void Start()
        {
            _auth = new Auth(new Service());
            var _botClient = Settings.botClient;
            _botClient.StartReceiving(Update, Error);
        }

        private async Task Update(ITelegramBotClient botClient, Update update, CancellationToken arg3)
        {
            var message = update.Message;
            if (message is not null)
            {
                var text = message.Text;
                var chatID = message.Chat.Id;
                // botClient.SendTextMessageAsync(chatID, text, replyMarkup: GetButtonsForClient());
                Console.WriteLine(text);
                 
                if (NewPassword == true)
                {
                    await botClient.SendTextMessageAsync(chatID, "qowildi");
                    
                    _auth.Register(log, text);
                    NewLog = null;
                    NewPassword = null;
                }
                if (NewLog == true)
                {
                    log = text;
                    await botClient.SendTextMessageAsync(chatID, "enter your new password: ");
                    NewLog = false;NewPassword = true;
                }
                
                if (text == "Register")
                {
                    await botClient.SendTextMessageAsync(chatID, "new log: ");
                    NewLog = true;
                }
                
                
               
            }
        }

        static ReplyKeyboardMarkup GetButtonsForClient()
        {
            ReplyKeyboardMarkup keyboard = new(new[]
                {
                    new KeyboardButton[] { "Login", "Register" },
                }
            )
            {
                ResizeKeyboard = true
            };
            return keyboard;
        }

        private Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            throw new NotImplementedException();
        }
    }
}