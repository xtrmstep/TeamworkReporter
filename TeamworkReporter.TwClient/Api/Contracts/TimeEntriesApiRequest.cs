using System.Runtime.Serialization;
using TeamworkReporter.TwClient.Data;

namespace TeamworkReporter.TwClient.Api.Contracts
{
    [DataContract]
    internal class TimeEntriesApiRequest : ApiRequest
    {
        [DataMember(Name = "time-entries")]
        public TwTimeEntry[] TimeEntries { get; set; }
    }
}