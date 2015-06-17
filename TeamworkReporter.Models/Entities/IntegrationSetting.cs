using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamworkReporter.Models
{
    /// <summary>
    /// Represents a set of settings used for Teamwork integration
    /// </summary>
    public class IntegrationSetting : DbEntity
    {
        public Account Account { get; set; }
    }
}
