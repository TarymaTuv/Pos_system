using Microsoft.Data.Sqlite;
using POS_Cafe_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Cafe_System.Commands
{
    public static class WorkerDB
    {
        static string _connectionString = "Data Source = " + Environment.CurrentDirectory + "Resources/CafeDB";//строка подключения к бд
        /// <summary>
        /// Проверка подключения к БД
        /// </summary>
        /// <returns></returns>
        public static bool IsConnect()
        {
            try
            {
                SqliteConnection connect = new SqliteConnection(_connectionString);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Считывание предметов(еды), которые участвуют в заказе
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ItemOrder> OrderItems()
        {
            List<ItemOrder> items = new List<ItemOrder>();
            string sqlliteQuery = "select * from Items;";
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(sqlliteQuery, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    int id = (int)reader["Id"];
                    string name = (string)reader["Name"];
                    byte[]image = (byte[])reader["Image"];
                    double price = (double)reader["Price"];
                    ItemOrder item = new ItemOrder(id, name, price, image);
                    items.Add(item);
                }
            }
            return items;
        }

    }
}
