using System.Runtime.Serialization;

namespace TeamworkReporter.TwClient.Data
{
    [DataContract]
    public class TwTask
    {
        [DataMember(Name = "project-id")]
        public string ProjectId { get; set; }

        [DataMember(Name = "creator-lastname")]
        public string CreatorLastName { get; set; }

        [DataMember(Name = "todo-list-name")]
        public string TodoListName { get; set; }

        [DataMember(Name = "order")]
        public int Order { get; set; }

        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "todo-list-id")]
        public int TodoListId { get; set; }

        [DataMember(Name = "created-on")]
        public string CreatedOn { get; set; }// todo change to DateTime

        [DataMember(Name = "company-name")]
        public string CompanyName { get; set; }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "creator-firstname")]
        public string CreatorFirstName { get; set; }

        [DataMember(Name = "last-changed-on")]
        public string LastChangedOn { get; set; }// todo change to DateTime

        [DataMember(Name = "due-date")]
        public string DueDate { get; set; }// todo change to DateTime

        [DataMember(Name = "completed")]
        public bool Completed { get; set; }

        [DataMember(Name = "position")]
        public int Position { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "parentTaskId")]
        public string ParentTaskId { get; set; } // todo change to int?

        [DataMember(Name = "company-id")]
        public int CompanyId { get; set; }

        [DataMember(Name = "canLogTime")]
        public bool CanLogTime { get; set; }

        [DataMember(Name = "creator-id")]
        public int CreatorId { get; set; }

        [DataMember(Name = "project-name")]
        public string ProjectName { get; set; }

        [DataMember(Name = "start-date")]
        public string StartDate { get; set; }

        [DataMember(Name = "timeIsLogged")]
        public string TimeIsLogged { get; set; }

        [DataMember(Name = "content")]
        public string Content { get; set; }
    }
}