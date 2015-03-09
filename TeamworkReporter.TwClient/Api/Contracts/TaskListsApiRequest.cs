using System.Runtime.Serialization;
using TeamworkReporter.TwClient.Data;

namespace TeamworkReporter.TwClient.Api.Contracts
{
    [DataContract]
    internal class TaskListsApiRequest : ApiRequest
    {
        [DataMember(Name = "todo-lists")]
        public TwTaskList[] TaskLists { get; set; }
    }
}