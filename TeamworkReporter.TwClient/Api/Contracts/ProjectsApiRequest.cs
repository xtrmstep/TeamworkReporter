using System.Runtime.Serialization;
using TeamworkReporter.TwClient.Data;

namespace TeamworkReporter.TwClient.Api.Contracts
{
    [DataContract]
    internal class ProjectsApiRequest : ApiRequest
    {
        [DataMember(Name="projects")]
        public TwProject[] Projects { get; set; }
    }
}