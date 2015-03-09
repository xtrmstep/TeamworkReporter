using System.Runtime.Serialization;

namespace TeamworkReporter.TwClient.Data
{
    [DataContract]
    public class TwTimeEntry
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "date")]
        public string Date { get; set; } // todo change to datetime

        [DataMember(Name = "hours")]
        public int Hours { get; set; }

        [DataMember(Name = "minutes")]
        public int Minutes { get; set; }

        [DataMember(Name = "person-id")]
        public int PersonId { get; set; }

        [DataMember(Name = "project-id")]
        public int ProjectId { get; set; }
        
        [DataMember(Name = "todo-list-name")]
        public string TaskListName { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "todo-item-name")]
        public string TaskName { get; set; }

        [DataMember(Name = "todo-list-id")]
        public string todo_list_id { get; set; }

        public int? TaskListId
        {
            get
            {
                int result;
                if (int.TryParse(todo_list_id, out result))
                    return result;
                return null;
            }
            set { todo_list_id = value.HasValue ? value.Value.ToString() : string.Empty; }
        }

        [DataMember(Name = "company-id")]
        public int CompanyId { get; set; }

        [DataMember(Name = "project-name")]
        public string ProjectName { get; set; }

        [DataMember(Name = "company-name")]
        public string CompanyName { get; set; }

        [DataMember(Name = "todo-item-id")]
        public string todo_item_id { get; set; }

        public int? TaskId
        {
            get
            {
                int result;
                if (int.TryParse(todo_item_id, out result))
                    return result;
                return null;
            }
            set { todo_item_id = value.HasValue ? value.Value.ToString() : string.Empty; }
        }

        [DataMember(Name = "person-first-name")]
        public string PersonFirstName { get; set; }

        [DataMember(Name = "person-last-name")]
        public string PersonLastName { get; set; }

    }
}