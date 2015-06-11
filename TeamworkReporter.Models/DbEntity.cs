using System;

namespace TeamworkReporter.Models
{
    public class DbEntity
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}
