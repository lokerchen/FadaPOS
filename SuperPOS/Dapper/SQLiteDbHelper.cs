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
        private const string DELETE_ITEM = "DELETE {0} FROM {1} ";
        private const string DELETE_ITEM_WHERE = "DELETE {0} FROM {1} WHERE {2}";

        private static SQLiteConnection strConn;

        public SQLiteDbHelper()
        {
            strConn = OpenConn();
        }

        #region 打开连接
        /// <summary>
        /// 打开连接
        /// </summary>
        /// <returns>数据库连接</returns>
        private SQLiteConnection OpenConn()
        {
            var conn = SQLiteBase.DbConnection();

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            return conn;
        }
        #endregion

        #region 查询
        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T">实体对象类</typeparam>
        /// <param name="strTblName">表名称</param>
        /// <param name="strWhere">WHERE语句</param>
        /// <param name="dynamicParams">参数内容</param>
        /// <returns></returns>
        public List<T> QueryMultiByWhere<T>(string strTblName, string strWhere, DynamicParameters dynamicParams)
        {
            try
            {
                try
                {
                    //Type type = typeof(T);
                    string strSql = "";

                    if (dynamicParams == null)
                    {
                        //strSql = string.Format(QUERY_ITEM, "*", type.Name);
                        strSql = string.Format(QUERY_ITEM, "*", strTblName);
                        return strConn.Query<T>(strSql).ToList();
                    }
                    else
                    {
                        strSql = string.Format(QUERY_ITEM_WHERE, "*", strTblName, strWhere);
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
        #endregion

        public bool InsertMulti<T>(string strSql, List<T> lst)
        {
            int result = strConn.Execute(strSql, lst);
            return result >= 1;
        }

        #region 删除

        public bool Delete<T>(string strTblName, string strWhere, DynamicParameters dynamicParams)
        {
            try
            {
                try
                {
                    //Type type = typeof(T);
                    string strSql = "";

                    if (dynamicParams == null)
                    {
                        //strSql = string.Format(QUERY_ITEM, "*", type.Name);
                        strSql = string.Format(DELETE_ITEM, "*", strTblName);
                        return strConn.Execute(strSql) >= 1;
                    }
                    else
                    {
                        strSql = string.Format(DELETE_ITEM_WHERE, "*", strTblName, strWhere);
                        return strConn.Execute(strSql, dynamicParams) >= 1;
                    }
                }
                catch (Exception e)
                {
                    LogHelper.Error("SQLiteDbHelper.QueryMultiByWhere.Error:" + e.InnerException);
                    return false;
                }
            }
            finally
            {
                Dispose();
            }
        }

        #endregion

        #region 释放连接
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
        #endregion

    }
}
