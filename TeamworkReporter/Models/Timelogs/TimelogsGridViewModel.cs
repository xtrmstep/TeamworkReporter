using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamworkReporter.Models.Timelogs
{
    public class TimelogsGridViewModel
    {
        /// <summary>
        /// Entry titles according to selecetd period
        /// </summary>
        public IEnumerable<string> Headers { get; set; }
        /// <summary>
        /// Time logs for user
        /// </summary>
        public IDictionary<string, IEnumerable<double>> Hours { get; set; }
    }
}