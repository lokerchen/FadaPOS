using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPOS.Dapper
{
    public class SQLiteBase
    {
        private static string DbFile
        {
            get { return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SuperPOS2.db"); }
        }

        public static SQLiteConnection DbConnection()
        {
            string strConn = $"Data Source={DbFile};";
            return new SQLiteConnection(strConn);
        }
    }
}
