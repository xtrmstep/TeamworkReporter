using System.Runtime.Serialization;
using TeamworkReporter.TwClient.Data;

namespace TeamworkReporter.TwClient.Api.Contracts
{
    [DataContract]
    internal class PersonApiRequest : ApiRequest
    {
        [DataMember(Name = "person")]
        public TwPerson Person { get; set; }
    }
}