using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Cafe_System.Commands
{
    public static class WorkerDB
    {
        static string _connectionString = "Data Source = " + Environment.CurrentDirectory + "Resources/CafeDB";       
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
    }
}
