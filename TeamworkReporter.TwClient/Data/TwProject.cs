using System.Runtime.Serialization;

namespace TeamworkReporter.TwClient.Data
{
    [DataContract]
    public class TwProject
    {
        [DataMember(Name = "company")]
        public TwCompany Company { get; set; }

        [DataMember(Name = "starred")]
        public bool Starred { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "isProjectAdmin")]
        public bool IsProjectAdmin { get; set; }

        [DataMember(Name = "createdOn")]
        public string CreatedOn { get; set; }// todo change to DateTime

        [DataMember(Name = "category")]
        public TwСategory Category { get; set; }

        [DataMember(Name = "startPage")]
        public string StartPage { get; set; }

        [DataMember(Name = "Logo")]
        public string Logo { get; set; }

        [DataMember(Name = "startDate")]
        public string StartDate { get; set; }// todo change to DateTime

        [DataMember(Name = "notifyEveryone")]
        public bool NotifyEveryone { get; set; }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "lastChangedOn")]
        public string LastChangedOn { get; set; }// todo change to DateTime

        [DataMember(Name = "endDate")]
        public string EndDate { get; set; } // todo change to DateTime

        protected bool Equals(TwProject other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TwProject) obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}