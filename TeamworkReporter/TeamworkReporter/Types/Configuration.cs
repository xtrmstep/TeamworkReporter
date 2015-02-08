using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamworkReporter.Types
{
    [Serializable]
    public class Configuration
    {
        public Configuration()
        {
            Account = string.Empty;
            Token = string.Empty;
        }

        public string Account { get; set; }
        public string Token { get; set; }
    }
}