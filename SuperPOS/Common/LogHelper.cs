using System;
using System.IO;
using System.Reflection;
using log4net;

//[assembly: log4net.Config.XmlConfigurator(ConfigFile = @"\log4net.config", Watch = true)]
[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace SuperPOS.Common
{
    public class LogHelper
    {
        private static ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static LogHelper()
        {
            log4net.Config.XmlConfigurator.Configure(new FileInfo(AppDomain.CurrentDomain.BaseDirectory + PubComm.LOG4NET_CONFIG_FILE_NAME));
        }

        #region 常规信息
        /// <summary>
        /// 常规信息
        /// </summary>
        /// <param name="message">记录信息</param>
        public static void Info(string message)
        {
            if (Log.IsInfoEnabled) Log.Info(message);
        }
        #endregion

        #region 警告信息
        /// <summary>
        /// 警告信息
        /// </summary>
        /// <param name="message">记录信息</param>
        public static void Warn(string message)
        {
            if (Log.IsWarnEnabled) Log.Warn(message);
        }
        #endregion

        #region 调试信息
        /// <summary>
        /// 调试信息
        /// </summary>
        /// <param name="message">记录信息</param>
        public static void Debug(string message)
        {
            if (Log.IsDebugEnabled) Log.Debug(message);
        }

        /// <summary>
        /// 调试信息
        /// </summary>
        /// <param name="message">记录信息</param>
        /// <param name="ex">异常信息</param>
        public static void Debug(string message, Exception ex)
        {
            if (Log.IsDebugEnabled) Log.Debug(message, ex);
        }
        #endregion

        #region 错误信息
        /// <summary>
        /// 错误信息
        /// </summary>
        /// <param name="message">记录信息</param>
        public static void Error(string message)
        {
            if (Log.IsErrorEnabled) Log.Error(message);
        }

        /// <summary>
        /// 错误信息
        /// </summary>
        /// <param name="message">记录信息</param>
        /// <param name="ex">异常信息</param>
        public static void Error(string message, Exception ex)
        {
            if (Log.IsErrorEnabled) Log.Error(message, ex);
        }
        #endregion
    }
}
