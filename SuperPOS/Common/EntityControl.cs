using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Xpo.DB.Helpers;
using DevExpress.Xpo.Helpers;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;
using SuperPOS.Domain.Entities;

namespace SuperPOS.Common
{
    class EntityControl
    {
        private static EntityControl _entity;
        private static readonly object Padlock = new object();

        #region 返回一个单例EntityControl
        /// <summary>
        ///     返回一个单例EntityControl
        /// </summary>
        /// <returns></returns>
        public static EntityControl CreateEntityControl()
        {
            if (_entity != null) return _entity;

            lock (Padlock)
            {
                if (_entity == null) _entity = new EntityControl();
            }

            return _entity;
        }

        #endregion

        #region 新增
        /// <summary>
        ///     新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool AddEntity(Object entity)
        {
            var flag = true;
            using (var session = SessionFactory.OpenSession())
            {
                try
                {
                    session.Save(entity);
                    session.Flush();
                }
                catch (Exception ex)
                {
                    LogHelper.Error(ex.Message, ex);
                    flag = false;
                }
            }
            return flag;
        }
        #endregion

        #region 新增或更新
        public void SaveOrUpdateEntity(Object entity)
        {
            using (var session = SessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.SaveOrUpdate(entity);
                        transaction.Commit();
                    }
                    catch(Exception ex)
                    {
                        LogHelper.Error(ex.Message, ex);
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        #endregion

        #region 更新对象
        public void UpdateEntity(Object entity)
        {
            using (var session = SessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(entity);
                        session.Flush();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Error(ex.Message, ex);
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        #endregion

        #region 更新对象，带参数
        public void UpdateEntity(Object entity, Object key)
        {
            ISession session = SessionFactory.OpenSession();
            ITransaction transaction = session.BeginTransaction();
            try
            {
                session.Update(entity, key);
                session.Flush();
                transaction.Commit();
            }
            catch (HibernateException hEx)
            {
                transaction?.Rollback();
                LogHelper.Error(hEx.Message, hEx);
                throw;
            }
            finally
            {
                session.Close();
            }
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除对象
        /// </summary>
        /// <param name="entity"></param>
        public void DeleteEntity(Object entity)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(entity);
                        transaction.Commit();
                    }
                    catch(Exception ex)
                    {
                        LogHelper.Error(ex.Message, ex);
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        #endregion

        #region 泛型方法，使用HQL指定条件和排序字段查询
        /// <summary>
        /// 泛型方法，使用HQL指定条件和排序字段查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sWhere">查询条件</param>
        /// <param name="sOrderBy">排序字段</param>
        /// <returns></returns>
        public IList<T> GetEntities<T>(string sWhere, string sOrderBy)
        {
            string query = " FROM " + typeof(T);

            if (!string.IsNullOrEmpty(sWhere))
                query += " WHERE " + sWhere;
            if (!string.IsNullOrEmpty(sOrderBy))
                query += " ORDER BY " + sOrderBy;

            IList<T> lst;
            using (ISession session = SessionFactory.OpenSession())
            {
                lst = session.CreateQuery(query).List<T>();
            }

            return lst;
        }
        #endregion

        #region 运行HQL查询语句
        /// <summary>
        /// 运行HQL查询语句
        /// </summary>
        /// <param name="sHql"></param>
        /// <returns></returns>
        public IList GetEntites(string sHql)
        {
            IList lst;
            using (ISession session = SessionFactory.OpenSession())
                lst = session.CreateQuery(sHql).List();
            return lst;
        }
        #endregion

        #region 使用原生SQL语句执行非查询操作
        /// <summary>
        /// 使用原生sql语句执行非查询操作
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public bool ExecuteSql(string strSql)
        {
            ISession session = null;
            ITransaction transaction = null;
            try
            {
                session = SessionFactory.OpenSession();
                transaction = session.BeginTransaction();
                ISQLQuery q = session.CreateSQLQuery(strSql);
                q.ExecuteUpdate();
                transaction.Commit();
                return true;
            }
            catch(Exception ex)
            {
                LogHelper.Error(ex.Message, ex);
                transaction?.Rollback();
                throw;
            }
            finally
            {
                session.Close();
            }
        }
        #endregion

        #region 使用原生SQL查询,返回数据封装为实体对象
        /// <summary>
        /// 使用原生SQL查询,返回数据封装为实体对象
        /// Author:charles
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>
        /// <param name="strSql">原生SQL语句</param>
        /// <returns></returns>
        IList<T> ExexuteSqlQuery<T>(string strSql)
        {
            ISession session = SessionFactory.OpenSession();
            try
            {
                ISQLQuery query = session.CreateSQLQuery(strSql).AddEntity("oi", typeof(T));
                return query.List<T>();
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message, ex);
                throw;
            }
            finally
            {
                session.Close();
            }
        }
        #endregion

        #region 查询所有
        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns>IList</returns>
        public IList<T> SelectAll<T>()
        {
            ISession session = SessionFactory.OpenSession();
            try
            {
                ICriteria ctRet = session.CreateCriteria(typeof(T));
                IList<T> list = ctRet.List<T>();
                return list;
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message, ex);
                throw;
            }
            finally
            {
                session.Close();
            }
        }
        #endregion

        #region MyRegion
        /// <summary>
        /// 查询过滤
        /// </summary>
        /// <returns></returns>
        public IList<T> SelectPart<T>(string strKey, Guid guid, string strorderby)
        {
            ISession session = null;
            try
            {
                session = SessionFactory.OpenSession();
                ICriteria ctRet = session.CreateCriteria(typeof(T));
                ctRet.Add(Expression.Eq(strKey, guid));
                if (!string.IsNullOrEmpty(strorderby)) ctRet.AddOrder(Order.Asc(strorderby));
                IList<T> list = ctRet.List<T>();
                return list;
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message, ex);
                throw;
            }
            finally
            {
                session?.Close();
            }
        }
        #endregion

        #region 建立List副本,使List的值修改后不影响
        /// <summary>
        /// 建立List副本,使List的值修改后不影响
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="list">源List</param>
        /// <returns></returns>
        public IList<T> ListClone<T>(IList<T> list)
        {
            try
            {
                return list.ToList();
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message, ex);
                throw;
            }
        }
        #endregion

        public IList<AccountSummaryInfo> GetAccountSummary()
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                string sql = "SELECT " +
                             "CO.ID AS ID," +
                             "CO.CheckCode AS CheckCode," +
                             "CO.PayType1 AS PayType1," +
                             "CO.PayType2 AS PayType2," +
                             "CO.PayType3 AS PayType3," +
                             "CO.PayType4 AS PayType4," +
                             "CO.PayType5 AS PayType5," +
                             "CO.PayOrderType AS PayOrderType," +
                             "CO.PayTime AS PayTime," +
                             "CO.TotalAmount AS TotalAmount," +
                             "TD.DriverName AS DriverName," +
                             "UB.UsrName AS UsrName," +
                             "CO.CustomerID AS CustomerID," +
                             "CO.PayPerDiscount AS PayPerDiscount," +
                             "CO.PayDiscount AS PayDiscount," +
                             "CO.MenuAmount AS MenuAmount," +
                             "CO.BusDate AS BusDate," +
                             "CO.Paid AS Paid," +
                             "CO.RefNum AS RefNum," +
                             "CO.DeliveryFee AS DeliveryFee," +
                             "CO.StaffID AS StaffID," +
                             "CO.PaySurcharge AS PaySurcharge," +
                             "CO.PayTypePay1 AS PayTypePay1," +
                             "CO.PayTypePay2 AS PayTypePay2," +
                             "CO.PayTypePay3 AS PayTypePay3," +
                             "CO.PayTypePay4 AS PayTypePay4," +
                             "CO.PayTypePay5 AS PayTypePay5 " +
                             "FROM Ta_CheckOrder CO " +
                             "LEFT JOIN Usr_Base UB ON CO.StaffID = UB.ID " +
                             "LEFT JOIN Ta_Driver TD ON CO.DriverID = TD.ID " +
                             "WHERE CO.IsPaid = 'Y'";
                //return session.CreateSQLQuery(sql).List<AccountSummaryInfo>();
                IList<object[]> query = session.CreateSQLQuery(sql).List<object[]>();
                IList<AccountSummaryInfo> result = query.Select(s => new AccountSummaryInfo(
                                                   s[0] == null ? 0 : Convert.ToInt32(s[0]),
                                                   s[1]?.ToString() ?? "",
                                                   s[2]?.ToString() ?? "",
                                                   s[3]?.ToString() ?? "",
                                                   s[4]?.ToString() ?? "",
                                                   s[5]?.ToString() ?? "",
                                                   s[6]?.ToString() ?? "",
                                                   s[7]?.ToString() ?? "",
                                                   s[8]?.ToString() ?? "",
                                                   s[9] == null ? 0.00m : Convert.ToDecimal(s[9]),
                                                   s[10]?.ToString() ?? "",
                                                   s[11]?.ToString() ?? "",
                                                   s[12] == null ? 0 : Convert.ToInt32(s[12]),
                                                   s[13]?.ToString() ?? "",
                                                   s[14] == null ? 0.00m : Convert.ToDecimal(s[14]),
                                                   s[15] == null ? 0.00m : Convert.ToDecimal(s[15]),
                                                   s[16]?.ToString() ?? "",
                                                   s[17]?.ToString() ?? "",
                                                   s[18]?.ToString() ?? "",
                                                   s[19] == null ? 0.00m : Convert.ToDecimal(s[19]),
                                                   s[20] == null ? 0 : Convert.ToInt32(s[20]),
                                                   s[21] == null ? 0.00m : Convert.ToDecimal(s[21]),
                                                   s[22]?.ToString() ?? "",
                                                   s[23]?.ToString() ?? "",
                                                   s[24]?.ToString() ?? "",
                                                   s[25]?.ToString() ?? "",
                                                   s[26]?.ToString() ?? ""
                                                   )).ToList();
                return result;
            }
                
        }
    }
}
