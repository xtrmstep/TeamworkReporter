using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamworkReporter.Models
{
    /// <summary>
    /// Represents an application setting
    /// </summary>
    public class AppSetting : DbEntity
    {
        /// <summary>
        /// Setting name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Text representation of data
        /// </summary>
        public string Value { get; set; }
    }
}
