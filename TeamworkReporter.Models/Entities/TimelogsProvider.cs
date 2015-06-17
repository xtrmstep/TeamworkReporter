using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamworkReporter.Models
{
    /// <summary>
    /// Represents a service which provides time logs
    /// </summary>
    public class TimelogsProvider: DbEntity
    {
        /// <summary>
        /// Provider internal name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Provider service API URL
        /// </summary>
        public string ServiceUrl { get; set; }

        /// <summary>
        /// Internal class which interacts with the provider API 
        /// </summary>
        public string ApiProxyClass { get; set; }
    }
}
