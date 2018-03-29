using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Criterion;

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
    }
}
