using System.Collections.Generic;

namespace TeamworkReporter.Models.Timelogs
{
    public class TimelogsGridViewModel
    {
        public TimelogsGridViewModel()
        {
            Headers = new string[] {};
            Hours = new Dictionary<string, IEnumerable<double>>();
            Totals = new Dictionary<string, double>();
        }

        /// <summary>
        ///     Entry titles according to selecetd period
        /// </summary>
        public IEnumerable<string> Headers { get; set; }

        /// <summary>
        ///     Time logs for periods for each of users
        /// </summary>
        public IDictionary<string, IEnumerable<double>> Hours { get; set; }

        /// <summary>
        ///     Totals for each of people for the selected period
        /// </summary>
        public IDictionary<string, double> Totals { get; set; }
    }
}