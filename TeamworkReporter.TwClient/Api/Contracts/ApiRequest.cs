using System.Runtime.Serialization;

namespace TeamworkReporter.TwClient.Api.Contracts
{
    [DataContract]
    class ApiRequest
    {
        [DataMember(Name = "STATUS")]
        public string Status { get; set; }
    }
}
