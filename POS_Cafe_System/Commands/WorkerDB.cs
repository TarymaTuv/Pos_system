﻿using System.Data.SQLite;
using POS_Cafe_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Packaging;

namespace POS_Cafe_System.Commands
{
    public static class WorkerDB
    {
        static string _connectionString = "Data Source = " + Environment.CurrentDirectory + "\\Resources\\CafeDB.db";//строка подключения к бд
        static List<ItemOrder> _itemsOrder = new List<ItemOrder>(); 

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
                    while (reader.Read())
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
            _itemsOrder = items;
            return items;
        }
        /// <summary>
        /// чтение заказов из бд
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Order> ReadAllOrder()
        {
            List<Order> orders = new List<Order>();
            string query = $"select * from Orders;";

            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(query, connection);

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //чтение из бд по названиям столбцов
                        string id = (string)reader["Id"];
                        bool isReady = ((string)reader["IsReady"] == "true");
                        bool isPay = ((string)reader["IsPay"] == "true");
                        double price = (double)reader["Price"];

                        //так как в бд хранятся id предмета и его кол-во, а также предметов много, делим строку на разделители(при записи это ; между разными предметами и пробелы между id и количеством)
                        string[] orderItems = ((string)reader["OrderItems"]).Split(';');
                        List< ItemOrder > itemsOrder = new List< ItemOrder >();

                        foreach (var item in orderItems)
                        {
                            //парсим строку
                            int idItem = int.Parse(item.Split(' ')[0]);
                            int countItem = int.Parse(item.Split(' ')[1]);

                            ItemOrder itemOrder = itemsOrder.Where(i => i.Id == idItem).First();
                            itemOrder.Count = countItem;
                            itemsOrder.Add(itemOrder);
                        }
                        //создаем заказ
                        Order order = new Order(itemsOrder);
                        order.Id = id; 
                        order.IsPay = isPay;
                        order.IsReady = isReady;
                        order.Price = price;

                        orders.Add(order);
                    }
                }
            }

            return orders;
        }
        /// <summary>
        /// удаление заказа из бд
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteOrder(string id)
        {
            string query = $"delete from Orders where Id ='{id}';";

            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.ExecuteNonQuery();
            }

            return true;
        }
        /// <summary>
        /// добавление заказа в бд
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public static bool AddOrder(Order order)
        {
            string query = "insert into Orders values (@id, @isReady, @isPay, @price, @orderItems);";
            string orderItemsString = "";

            //так как все предметы всё равно хранятся в бд, сохраняем только id предмета и его количество
            foreach (var item in order.OrderItems)
            {
                orderItemsString += $"{item.Id} {item.Count};";
            }

            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(query, connection);

                command.Parameters.AddWithValue("@id", order.Id);
                command.Parameters.AddWithValue("@isReady", order.IsReady);
                command.Parameters.AddWithValue("@isPay", order.IsPay);
                command.Parameters.AddWithValue("@price", order.Price);
                command.Parameters.AddWithValue("@orderItems", orderItemsString); 
                
                int number = command.ExecuteNonQuery();
                Console.WriteLine($"Добавлено объектов: {number}");
            }

            return true;
        }
        /// <summary>
        /// обновление заказа в бд, сообщение о его готовности
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool ReadyOrder(string id)
        {
            string query = $"update Orders set IsReady = 'true' where Id ='{id}';";

            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.ExecuteNonQuery();
            }

            return true;
        }

    }
}
