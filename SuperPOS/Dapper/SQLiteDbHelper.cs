using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using SuperPOS.Common;

namespace SuperPOS.Dapper
{
    public class SQLiteDbHelper : IDisposable
    {
        private const string QUERY_ITEM_WHERE = "SELECT {0} FROM {1} WHERE {2}";
        private const string QUERY_ITEM = "SELECT {0} FROM {1} ";

        private static SQLiteConnection strConn;

        public SQLiteDbHelper()
        {
            strConn = OpenConn();
        }

        private SQLiteConnection OpenConn()
        {
            var conn = SQLiteBase.DbConnection();

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            return conn;
        }

        public List<T> QueryMultiByWhere<T>(string strTblName, string strWhere, DynamicParameters dynamicParams)
        {
            try
            {
                try
                {
                    Type type = typeof(T);
                    string strSql = "";

                    if (dynamicParams == null)
                    {
                        //strSql = string.Format(QUERY_ITEM, "*", type.Name);
                        strSql = string.Format(QUERY_ITEM, "*", strTblName);
                        return strConn.Query<T>(strSql).ToList();
                    }
                    else
                    {
                        string.Format(QUERY_ITEM_WHERE, "*", strTblName, strWhere);
                        return strConn.Query<T>(strSql, dynamicParams).ToList();
                    }
                }
                catch (Exception e)
                {
                    LogHelper.Error("SQLiteDbHelper.QueryMultiByWhere.Error:" + e.InnerException);
                    return null;
                }
            }
            finally
            {
                Dispose();
            }
            
        }

        public void Dispose()
        {
            if (strConn != null)
            {
                try
                {
                    strConn.Close();
                    strConn.Dispose();
                }
                catch (Exception e)
                {
                    LogHelper.Error("SQLiteDbHelper.Dispose.Error:" + e.InnerException);
                }
            }
        }
    }
}
