using System;
using System.Diagnostics;

namespace TeamworkReporter.TwClient.Logging
{
    class DefaultLog : ILog
    {
        public void Debug(string message)
        {
            Info(message);
        }

        public void Info(string message)
        {
            Trace.TraceInformation(message);
        }

        public void Warn(string message)
        {
            Trace.TraceWarning(message);
        }

        public void Error(string message)
        {
            Trace.TraceError(message);
        }

        public void Error(Exception exception)
        {
            Error(exception, exception.Message);
        }

        public void Error(Exception exception, string message)
        {
            Trace.TraceError("Error of type \"{0}\" with message: \"{1}\"", exception.GetType().Name, message);
            Trace.TraceError("Stack trace: \"{0}\"", exception.StackTrace);
            Trace.TraceError("Source: \"{0}\"", exception.Source);
        }
    }
}
