using System.Runtime.Serialization;

namespace TeamworkReporter.TwClient.Data
{
    [DataContract]
    public class TwCompany
    {
        [DataMember(Name="name")]
        public string Name { get; set; }

        [DataMember(Name = "isOwner")]
        public string IsOwner { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }
    }
}