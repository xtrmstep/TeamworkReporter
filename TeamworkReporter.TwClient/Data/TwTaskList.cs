using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TeamworkReporter.TwClient.Data
{
    [DataContract]
    public class TwTaskList
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "project-id")]
        public int ProjectId { get; set; }

        [DataMember(Name = "todo-items")]
        public IEnumerable<TwTask> Tasks { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "complete")]
        public bool Completed { get; set; }

        [DataMember(Name = "project-name")]
        public string ProjectName { get; set; }

        [DataMember(Name = "position")]
        public int Position { get; set; }
    }
}