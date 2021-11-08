using gateway_api_final.Contracts;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gateway_api_final.Logger
{
    public class LoggerManager : ILoggerManager
    {
        private static readonly NLog.ILogger logger = LogManager.GetCurrentClassLogger();
        public void LogDebug(string message)
        {
            logger.Debug(message);
        }
        public void LogError(string message)
        {
            logger.Error(message);
        }
        public void LogInfo(string message)
        {
            logger.Info(message);
        }
        public void LogWarn(string message)
        {
            logger.Warn(message);
        }
    }
}
