using System.Runtime.Serialization;

namespace TeamworkReporter.TwClient.Data
{
    [DataContract]
    public class TwPerson
    {
        [DataMember(Name = "administrator")]
        public bool IsAdmin { get; set; }

        [DataMember(Name = "user-name")]
        public string UserName { get; set; }

        [DataMember(Name = "company-name")]
        public string CompanyName { get; set; }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "first-name")]
        public string FirstName { get; set; }

        [DataMember(Name = "last-name")]
        public string LastName { get; set; }

        [DataMember(Name = "companyId")]
        public int CompanyId { get; set; }

        [DataMember(Name = "avatar-url")]
        public string AvatarUrl { get; set; }

        [DataMember(Name = "user-type")]
        public string UserType { get; set; }

        [DataMember(Name = "email-address")]
        public string Email { get; set; }

        protected bool Equals(TwPerson other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TwPerson) obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}