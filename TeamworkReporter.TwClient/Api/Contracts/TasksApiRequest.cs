using System.Runtime.Serialization;
using TeamworkReporter.TwClient.Data;

namespace TeamworkReporter.TwClient.Api.Contracts
{
    [DataContract]
    internal class TasksApiRequest : ApiRequest
    {
        [DataMember(Name = "todo-items")]
        public TwTask[] Tasks { get; set; }
    }
}