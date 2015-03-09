using System;

namespace TeamworkReporter.TwClient.Logging
{
    class DefaultLogFactory : ILogFactory
    {
        public ILog Get(Type type)
        {
            return new DefaultLog();
        }
    }
}
