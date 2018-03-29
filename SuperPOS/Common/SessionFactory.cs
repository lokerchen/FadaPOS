using System;
using NHibernate;

namespace SuperPOS.Common
{
    public class SessionFactory
    {
        private static ISessionFactory _sessions;
        private static readonly object PadLock = new object();
        private static NHibernate.Cfg.Configuration _cfg;

        public static ISession OpenSession()
        {
            if (_sessions != null) return _sessions.OpenSession();

            lock (PadLock)
            {
                if (_sessions == null) BuildSessionFactory();
            }

            return _sessions.OpenSession();
        }

        private static void BuildSessionFactory()
        {
            _cfg = new NHibernate.Cfg.Configuration();

            try
            {
                _sessions = _cfg.Configure(PubComm.NHIBERNATE_CONFIG_FILE_NAME).BuildSessionFactory();
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message, ex);
                throw;
            }
        }
    }
}
