using System.Runtime.Serialization;
using TeamworkReporter.TwClient.Data;

namespace TeamworkReporter.TwClient.Api.Contracts
{
    [DataContract]
    internal class TaskApiRequest : ApiRequest
    {
        [DataMember(Name = "todo-item")]
        public TwTask Task { get; set; }
    }
}