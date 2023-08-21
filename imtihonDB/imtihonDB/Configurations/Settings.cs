using Npgsql;
using Telegram.Bot;

namespace imtihonDB.Configurations
{
    public class Settings
    {
        public static NpgsqlConnection com =
            new NpgsqlConnection(
                @"Server=localhost;port=5432;User id = postgres; Password = Xontaxta*2; Database = postgres;");

        public static TelegramBotClient botClient =
            new TelegramBotClient("6484711582:AAGpc0ZFNppJI8TqqP-YkwihyRBSK4ay9Ls");
    }
}