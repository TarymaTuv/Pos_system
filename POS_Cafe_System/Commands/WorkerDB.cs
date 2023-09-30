using System.Data.SQLite;
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
        static string _connectionString = "Data Source = " + Environment.CurrentDirectory + "\\Resources\\CafeDB.db";//строка подключения к бд
        /// <summary>
        /// Проверка подключения к БД
        /// </summary>
        /// <returns></returns>
        public static bool IsConnect()
        {
            try
            {
                SQLiteConnection connect = new SQLiteConnection(_connectionString);
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
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(sqlliteQuery, connection);
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        int id = (int)reader.GetInt32(0);
                        string name = (string)reader.GetValue(1);
                        byte[] image = (byte[])reader.GetValue(2);
                        double price = (double)reader.GetValue(3);

                        ItemOrder item = new ItemOrder(id, name, price, image);
                        items.Add(item);
                    }
                }
            }
            return items;
        }

    }
}
