using System.Runtime.Serialization;
using TeamworkReporter.TwClient.Data;

namespace TeamworkReporter.TwClient.Api.Contracts
{
    [DataContract]
    internal class PeopleApiRequest : ApiRequest
    {
        [DataMember(Name = "people")]
        public TwPerson[] People { get; set; }
    }
}