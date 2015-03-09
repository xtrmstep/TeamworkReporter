using System;

namespace TeamworkReporter.TwClient.Logging
{
    public interface ILogFactory
    {
        ILog Get(Type type);
    }
}
