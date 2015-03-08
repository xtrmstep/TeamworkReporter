using System.Collections.Generic;

namespace TeamworkReporter.Models.Timelogs
{
    public class TimelogsViewModel
    {
        /// <summary>
        /// All people which can be observed
        /// </summary>
        public IEnumerable<PersonViewModel> People { get; set; }
        /// <summary>
        /// People to show time logs
        /// </summary>
        public IEnumerable<PersonViewModel> SelectedPeople { get; set; }
        //Time log aggragation period
        public TimelogsPeriod Period { get; set; }
        public TimelogsGridViewModel Grid { get; set; }
    }
}