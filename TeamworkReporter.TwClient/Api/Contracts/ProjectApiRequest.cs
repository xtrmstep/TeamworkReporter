using System.Runtime.Serialization;
using TeamworkReporter.TwClient.Data;

namespace TeamworkReporter.TwClient.Api.Contracts
{
    [DataContract]
    class ProjectApiRequest : ApiRequest
    {
        [DataMember(Name = "project")]
        public TwProject Project { get; set; }
    }
}