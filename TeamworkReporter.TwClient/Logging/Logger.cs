namespace TeamworkReporter.TwClient.Logging
{
    public static class Logger
    {
        private static ILogFactory _factory;

        public static void SetLogger(ILogFactory factory)
        {
            _factory = factory;
        }
        
        internal static ILog For<T>()
        {
            return _factory.Get(typeof (T));
        }
    }
}
