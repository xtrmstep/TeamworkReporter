using System.Web;

namespace TeamworkReporter.Types
{
    public class Settings
    {
        private const string CONFIGURATION = "Configuration";
        private const string STORAGE = "Storage";

        public static Configuration Config
        {
            get { return HttpContext.Current.Items[CONFIGURATION] as Configuration; }
            set
            {
                if (HttpContext.Current.Items.Contains(CONFIGURATION) == false)
                    HttpContext.Current.Items.Add(CONFIGURATION, value);
                else
                    HttpContext.Current.Items[CONFIGURATION] = value;
            }
        }

        public static ConfigurationStorage Storage
        {
            get { return HttpContext.Current.Items[STORAGE] as ConfigurationStorage; }
            set
            {
                if (HttpContext.Current.Items.Contains(STORAGE) == false)
                    HttpContext.Current.Items.Add(STORAGE, value);
                else
                    HttpContext.Current.Items[STORAGE] = value;
            }
        }
    }
}