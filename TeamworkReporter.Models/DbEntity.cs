using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamworkReporter.Models
{
    public abstract class DbEntity
    {
        public DbEntity()
        {
            CreatedDate = DateTimeOffset.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public DateTimeOffset CreatedDate { get; private set; }
    }
}
