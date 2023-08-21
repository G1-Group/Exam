using System;
using imtihonDB.Configurations;
using imtihonDB.domain.model;
using imtihonDB.service;
using Npgsql;

namespace imtihonDB.auth
{
    public class Auth
    {
        private Service _service;
        
        public Auth(Service service)
        {
            _service = service;
        }

        public void Register(string log, string pass)
        {
            _service.Register(new User()
            {
                Login = log,
                Password = pass,
            });
        }

        static void Create()
        {
            using (Settings.com)
            {
                string query = @"insert into sxema.userlar values ('Jasur', 50)";
                Settings.com.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, Settings.com);
                int n = cmd.ExecuteNonQuery();
                if (n == 1)
                {
                    Console.WriteLine("Record inserted");
                }
            }
        }
    }
}