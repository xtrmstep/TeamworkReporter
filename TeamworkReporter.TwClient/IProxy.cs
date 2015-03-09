namespace TeamworkReporter.TwClient
{
    public interface IProxy
    {
        /// <summary>
        /// Determines whether API has all required settings to interact properly with TeamworkPM
        /// </summary>
        bool IsInitialized { get; }
        
    }
}