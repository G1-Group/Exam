using System;
using System.Data.Common;
using imtihonDB.Configurations;
using imtihonDB.domain.model;
using Npgsql;
using NpgsqlTypes;

namespace imtihonDB.service
{
    public class Service
    {
        public Service()
        {
           
        }

        static void CreateTableStudents()
        {
            using (Settings.com)
            {
                string q = @"CREATE SCHEMA sxema1;";
                string query = @"CREATE TABLE sxema1.students (id int, first_name varchar(130), last_name varchar(130),
                login varchar(200),
                password varchar(140));";
                Settings.com.Open();
                new NpgsqlCommand(q, Settings.com).ExecuteNonQuery();
                new NpgsqlCommand(query, Settings.com).ExecuteNonQuery();
                // Settings.com.Close();
            }
        }

        public void Register(User user)
        {
            using (Settings.com)
            {
                string query = $@"insert into sxema1.students (id, login, password) values ({user.id}, '{user.Login}', '{user.Password}';)";
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