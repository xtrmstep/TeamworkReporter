using System;

namespace TeamworkReporter.TwClient.Logging
{
    public interface ILog
    {
        void Debug(string message);
        void Info(string message);
        void Warn(string message);
        void Error(string message);
        void Error(Exception exception);
        void Error(Exception exception, string message);
    }
}