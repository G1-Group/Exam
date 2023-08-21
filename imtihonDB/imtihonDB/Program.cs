using System;
using imtihonDB.bot;
using imtihonDB.Configurations;
using Npgsql;

namespace imtihonDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            new TelegramBot().Start();
            Console.ReadKey();
        }
        
        static void Insert()
        {
            using (Settings.com)
            {
                string query = @"insert into sxema.userlar values ('Jasur', 50)";
                Settings.com.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, Settings.com);
                int n = cmd.ExecuteNonQuery();
                if (n==1)
                {
                    Console.WriteLine("Record inserted");
                }
            }
        }
    }
}