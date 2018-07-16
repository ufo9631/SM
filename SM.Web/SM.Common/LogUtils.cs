using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SM.Common
{
    public class LogUtils
    {
        private static ILog loggerInfo;
        private static ILog loggerDebug;
        private static ILog loggerError;
        static LogUtils()
        {
            if (loggerInfo == null || loggerDebug == null || loggerError == null)
            {
                var repository = LogManager.CreateRepository("NETCoreRepository");
                //log4net从log4net.config文件中读取配置信息
                XmlConfigurator.Configure(repository, new FileInfo("Config\\log4net.config"));
                loggerInfo = LogManager.GetLogger(repository.Name, "Info");
                loggerDebug = LogManager.GetLogger(repository.Name, "Debug");
                loggerError = LogManager.GetLogger(repository.Name, "Error");
            }
        }

        /// <summary>
        /// 普通日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static void Info(string message, Exception exception = null)
        {
            if (exception == null)
                loggerInfo.Info(message);
            else
                loggerInfo.Info(message, exception);
        }

        /// <summary>
        /// 告警日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        //public static void Warn(string message, Exception exception = null)
        //{
        //    if (exception == null)
        //        logger.Warn(message);
        //    else
        //        logger.Warn(message, exception);
        //}

        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static void Error(string message, Exception exception = null)
        {
            if (exception == null)
                loggerError.Error(message);
            else
                loggerError.Error(message, exception);
        }

        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static void Debug(string message, Exception exception = null)
        {
            if (exception == null)
                loggerDebug.Debug(message);
            else
                loggerDebug.Debug(message, exception);
        }
    }
}
