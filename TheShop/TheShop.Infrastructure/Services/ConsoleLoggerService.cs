using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Application.Common.Interfaces;

namespace TheShop.Infrastructure.Services
{
    public enum LogLevel
    {
        Trace = 0,
        Debug = 1,
        Information = 2,
        Warning = 3,
        Error = 4,
        Critical = 5,
        None = 6
    }
    public class ConsoleLoggerService : ILogger
    {
        private readonly LogLevel _logLevel;

        public ConsoleLoggerService(LogLevel logLevel = LogLevel.Debug)
        {
            _logLevel = logLevel;
        }
        public void LogDebug(string message)
        {
            LogToConsole(LogLevel.Debug, message);
        }

        public void LogError(string message)
        {
            LogToConsole(LogLevel.Error, message);
        }

        public void LogInfo(string message)
        {
            LogToConsole(LogLevel.Information, message);
        }

        private void LogToConsole(LogLevel level, string message)
        {
            if (level >= _logLevel)
            {
                Console.WriteLine($"{DateTime.Now}: {level} : {message}");   
            }
        }
    }
}
