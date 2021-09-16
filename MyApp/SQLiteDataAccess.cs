using Dapper;
using MyApp.UserControlWindows.Health.Counter;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp
{
    public class SQLiteDataAccess
    {
        public static List<CalculateModel> LoadItems()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<CalculateModel>("select * from items_table", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void SaveItem(CalculateModel item)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into items_table (ItemName, CaloriesPer100) values (@ItemName, @CaloriesPer100)", item);
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
