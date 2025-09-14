using System;
using System.Collections.Generic;
using System.IO;

namespace Utility
{
    public static class LogUtility
    {
        public enum LogLevel
        {
            Verbose,
            Log,
            Info,
            Warning,
            Error,
            Mute,
        }

        public interface ILog : IDisposable
        {
            public void SetLogLevel(LogLevel level);
            public void Log(LogLevel level, string msg);
        }


        public class DefaultLogger : ILog
        {
            protected LogLevel logLevel = LogLevel.Log;
            protected readonly string uniqueTag = null;
            private StreamWriter streamWriter = null;
            private static readonly Dictionary<string, StreamWriter> cacheStreams = new();
            
            // 可能存在不同 tag 写到同一个文件的情况？
            // 是不是应该把 stream 共享？

            public DefaultLogger(string tag, string filename)
            {
                uniqueTag = tag;
                string fullPath = PathUtility.GetPersistentFullPath($"logs/{filename}");
                streamWriter = new StreamWriter(fullPath, true);
            }

            public void SetLogLevel(LogLevel level)
            {
                logLevel = level;
            }

            public void Log(LogLevel level, string msg)
            {
                if (level < logLevel)
                    return;
            }

            protected virtual void LogInternal(LogLevel level, string msg)
            {
                // 1. Log-Head   [INFO] 2025-09-14 01:20.123 [uniqueTag] Hello world
            }

            public void Dispose()
            {
                streamWriter.Dispose();
            }
        }

        public static readonly ILog Debug = new DefaultLogger("Debug", "debug.log");
    }
}