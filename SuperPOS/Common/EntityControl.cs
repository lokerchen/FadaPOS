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

        public PrtAccountSummaryInfo GetPrtAccountSummary(string strOrderNum, string strBusDate)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                string sql = "SELECT " +
                             "SUM(DeliveryFee) AS DeliveryFee," +
                             "SUM(CASE WHEN PayOrderType = 'SHOP' THEN 1 ELSE 0 END) AS ShopCount," +
                             "SUM(CASE WHEN PayOrderType = 'SHOP' THEN TotalAmount ELSE 0 END) AS ShopAmount," +
                             "SUM(CASE WHEN PayOrderType = 'DELIVERY' THEN 1 ELSE 0 END) AS DeliveryCount," +
                             "SUM(CASE WHEN PayOrderType = 'DELIVERY' THEN TotalAmount ELSE 0 END) AS DeliveryAmount," +
                             "SUM(CASE WHEN PayOrderType = 'COLLECTION' THEN 1 ELSE 0 END) AS CollectionCount," +
                             "SUM(CASE WHEN PayOrderType = 'COLLECTION' THEN TotalAmount ELSE 0 END) AS CollectionAmount," +
                             "SUM(CASE WHEN CAST(PayTypePay1 AS NUMERIC) > 0 THEN 1 ELSE 0 END) AS PayType1Count," +
                             "SUM(CASE WHEN CAST(PayTypePay1 AS NUMERIC) > 0 THEN PayTypePay1 ELSE 0 END) AS PayType1Amount," +
                             "SUM(CASE WHEN CAST(PayTypePay2 AS NUMERIC) > 0 THEN 1 ELSE 0 END) AS PayType2Count," +
                             "SUM(CASE WHEN CAST(PayTypePay2 AS NUMERIC) > 0 THEN PayTypePay2 ELSE 0 END) AS PayType2Amount," +
                             "SUM(CASE WHEN CAST(PayTypePay3 AS NUMERIC) > 0 THEN 1 ELSE 0 END) AS PayType3Count," +
                             "SUM(CASE WHEN CAST(PayTypePay3 AS NUMERIC) > 0 THEN PayTypePay3 ELSE 0 END) AS PayType3Amount," +
                             "SUM(CASE WHEN CAST(PayTypePay4 AS NUMERIC) > 0 THEN 1 ELSE 0 END) AS PayType4Count," +
                             "SUM(CASE WHEN CAST(PayTypePay4 AS NUMERIC) > 0 THEN PayTypePay4 ELSE 0 END) AS PayType4Amount," +
                             "SUM(CASE WHEN CAST(PayTypePay5 AS NUMERIC) > 0 THEN 1 ELSE 0 END) AS PayType5Count," +
                             "SUM(CASE WHEN CAST(PayTypePay5 AS NUMERIC) > 0 THEN PayTypePay5 ELSE 0 END) AS PayType5Amount," +
                             "SUM(CASE WHEN PayOrderType = 'FAST FOOD' THEN 1 ELSE 0 END) AS FastFoodCount," +
                             "SUM(CASE WHEN PayOrderType = 'FAST FOOD' THEN TotalAmount ELSE 0 END) AS FastFoodAmount " +
                             "FROM Ta_CheckOrder WHERE IsPaid = 'Y'";
                if (!string.IsNullOrEmpty(strOrderNum)) sql += " AND CheckCode IN (" + strOrderNum + ")";
                if (!string.IsNullOrEmpty(strBusDate)) sql += " AND BusDate='" + strBusDate + "'";
                IList<object[]> query = session.CreateSQLQuery(sql).List<object[]>();
                IList<PrtAccountSummaryInfo> result = query.Select(s => new PrtAccountSummaryInfo(
                                                   s[0] == null ? 0.00m : Convert.ToDecimal(s[0]),
                                                   s[1] == null ? 0 : Convert.ToInt32(s[1]),
                                                   s[2] == null ? 0.00m : Convert.ToDecimal(s[2]),
                                                   s[3] == null ? 0 : Convert.ToInt32(s[3]),
                                                   s[4] == null ? 0.00m : Convert.ToDecimal(s[4]),
                                                   s[5] == null ? 0 : Convert.ToInt32(s[5]),
                                                   s[6] == null ? 0.00m : Convert.ToDecimal(s[6]),
                                                   s[7] == null ? 0 : Convert.ToInt32(s[7]),
                                                   s[8] == null ? 0.00m : Convert.ToDecimal(s[8]),
                                                   s[9] == null ? 0 : Convert.ToInt32(s[9]),
                                                   s[10] == null ? 0.00m : Convert.ToDecimal(s[10]),
                                                   s[11] == null ? 0 : Convert.ToInt32(s[11]),
                                                   s[12] == null ? 0.00m : Convert.ToDecimal(s[12]),
                                                   s[13] == null ? 0 : Convert.ToInt32(s[13]),
                                                   s[14] == null ? 0.00m : Convert.ToDecimal(s[14]),
                                                   s[15] == null ? 0 : Convert.ToInt32(s[15]),
                                                   s[16] == null ? 0.00m : Convert.ToDecimal(s[16]),
                                                   s[17] == null ? 0 : Convert.ToInt32(s[17]),
                                                   s[18] == null ? 0.00m : Convert.ToDecimal(s[18])
                                                   )).ToList();
                return result.FirstOrDefault();
            }
        }

        public IList<OrderItemSumForVatInfo> GetOrderItemSumForVatInfos(string strOrderNum, string strBusDate)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                string sql = "SELECT MI.MiRmk AS MiRmk, OI.ItemTotalPrice AS ItemTotalPrice" +
                             " FROM Ta_OrderItem OI LEFT JOIN Ta_MenuItem MI ON OI.ItemCode = MI.MiDishCode" +
                             " LEFT JOIN Ta_CheckOrder CO ON OI.CheckCode = CO.CheckCode AND OI.BusDate = CO.BusDate " +
                             " WHERE MI.MiRmk LIKE '%Without VAT%'";
                if (!string.IsNullOrEmpty(strOrderNum)) sql += " AND OI.CheckCode IN (" + strOrderNum + ")";
                if (!string.IsNullOrEmpty(strBusDate)) sql += " AND OI.BusDate='" + strBusDate + "'";
                IList<object[]> query = session.CreateSQLQuery(sql).List<object[]>();
                IList<OrderItemSumForVatInfo> result = query.Select(s => new OrderItemSumForVatInfo(
                                                                    s[0]?.ToString() ?? "",
                                                                    s[1] == null ? 0.00m : Convert.ToDecimal(s[1])
                                                                    )).ToList();
                return result;
            }
        }

        public IList<RptTotalSalesInfo> GetRptTotalSales(string strBusDate)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                string sql = "SELECT OI.ItemCode AS ItemCode, OI.ItemDishName AS ItemDishName, OI.ItemDishOtherName AS ItemDishOtherName, " +
                             "SUM(OI.ItemQty) AS ItemQty, SUM(OI.ItemTotalPrice)AS ItemTotalPrice " +
                             "FROM Ta_OrderItem OI LEFT JOIN Ta_CheckOrder CO ON OI.CheckCode = CO.CheckCode AND OI.BusDate = CO.BusDate " +
                             "WHERE CO.IsPaid = 'Y' AND OI.ItemType = '1' AND CO.BusDate = '" + strBusDate + "'" + 
                             "GROUP BY OI.ItemCode, OI.ItemDishName, OI.ItemDishOtherName " + 
                             "ORDER BY ItemQty DESC, ItemTotalPrice DESC";
                IList<object[]> query = session.CreateSQLQuery(sql).List<object[]>();
                IList<RptTotalSalesInfo> result = query.Select(s => new RptTotalSalesInfo(
                                                                    s[0]?.ToString() ?? "",
                                                                    s[1]?.ToString() ?? "",
                                                                    s[2]?.ToString() ?? "",
                                                                    s[3] == null ? 0 : Convert.ToInt32(s[3]),
                                                                    s[4] == null ? 0.00m : Convert.ToDecimal(s[4])
                                                                    )).ToList();
                return result;
            }
        }

        public IList<ShowAndPendOrderDataInfo> GetShowAndPendOrderData(string strOrderNum, string strBusDate)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                string sql = "SELECT CO.ID AS ID, CO.CheckCode AS CheckCode, TC.cusPostcode AS CustPostCode, TC.cusPcZone AS CustPcZone, TC.cusAddr AS CustAddr, CO.PayOrderType AS PayOrderType, " +
                             "TC.cusName AS CustName, TC.cusPhone AS CustPhone, CO.IsPaid AS IsPaid, CO.TotalAmount AS TotalAmount, UB.UsrName AS UsrName, CO.Paid AS Paid, CO.CustomerID AS CustID, " +
                             "CO.DriverID AS DriverID, TD.DriverName AS DriverName, CO.MenuAmount AS MenuAmount, CO.PayDiscount AS PayDiscount, CO.PayPerDiscount AS PayPerDiscount, CO.IsSave AS IsSave, " +
                             "CO.BusDate AS BusDate, CO.RefNum AS RefNum, CO.DeliveryFee AS DeliveryFee, CO.PaySurcharge AS PaySurcharge, CO.PayPerSurcharge AS PayPerSurcharge, " +
                             "CO.PayType1 AS PayType1, CO.PayType2 AS PayType2, CO.PayType3 AS PayType3, CO.PayType4 AS PayType4, CO.PayType5 AS PayType5, " +
                             "CO.PayTypePay1 AS PayTypePay1, CO.PayTypePay2 AS PayTypePay2, CO.PayTypePay3 AS PayTypePay3, CO.PayTypePay4 AS PayTypePay4, CO.PayTypePay5 AS PayTypePay5, " + 
                             "CO.IsCancel AS IsCancel, CO.PayTime AS PayTime, CO.StaffID AS StaffID " +
                             "FROM Ta_CheckOrder CO " +
                             "LEFT JOIN Usr_Base UB ON CO.StaffID = UB.ID LEFT JOIN Ta_Driver TD ON CO.DriverID = TD.ID " +
                             "LEFT JOIN Ta_Customer TC ON CO.CustomerID = TC.ID WHERE CO.CheckCode IS NOT NULL";
                if (!string.IsNullOrEmpty(strOrderNum)) sql += " AND CO.CheckCode ='" + strOrderNum + "'";
                if (!string.IsNullOrEmpty(strBusDate)) sql += " AND CO.BusDate='" + strBusDate + "'";
                IList<object[]> query = session.CreateSQLQuery(sql).List<object[]>();
                IList<ShowAndPendOrderDataInfo> result = query.Select(s => new ShowAndPendOrderDataInfo(
                                                                        s[0] == null ? 0 : Convert.ToInt32(s[0]),
                                                                        s[1]?.ToString() ?? "",
                                                                        s[2]?.ToString() ?? "",
                                                                        s[3]?.ToString() ?? "",
                                                                        s[4]?.ToString() ?? "",
                                                                        s[5]?.ToString() ?? "",
                                                                        s[6]?.ToString() ?? "",
                                                                        s[7]?.ToString() ?? "",
                                                                        s[8]?.ToString() ?? "",
                                                                        s[9]?.ToString() ?? "",
                                                                        s[10]?.ToString() ?? "",
                                                                        s[11]?.ToString() ?? "",
                                                                        s[12]?.ToString() ?? "",
                                                                        s[13]?.ToString() ?? "",
                                                                        s[14]?.ToString() ?? "",
                                                                        s[15]?.ToString() ?? "",
                                                                        s[16]?.ToString() ?? "",
                                                                        s[17]?.ToString() ?? "",
                                                                        s[18]?.ToString() ?? "",
                                                                        s[19]?.ToString() ?? "",
                                                                        s[20]?.ToString() ?? "",
                                                                        s[21]?.ToString() ?? "",
                                                                        s[22]?.ToString() ?? "",
                                                                        s[23]?.ToString() ?? "",
                                                                        s[24]?.ToString() ?? "",
                                                                        s[25]?.ToString() ?? "",
                                                                        s[26]?.ToString() ?? "",
                                                                        s[27]?.ToString() ?? "",
                                                                        s[28]?.ToString() ?? "",
                                                                        s[29]?.ToString() ?? "",
                                                                        s[30]?.ToString() ?? "",
                                                                        s[31]?.ToString() ?? "",
                                                                        s[32]?.ToString() ?? "",
                                                                        s[33]?.ToString() ?? "",
                                                                        s[34]?.ToString() ?? "",
                                                                        s[35]?.ToString() ?? "",
                                                                        s[36]?.ToString() ?? ""
                                                                        )).ToList();
                return result;
            }
        }

    }
}
