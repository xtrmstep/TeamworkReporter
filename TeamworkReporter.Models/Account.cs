using System;

namespace TeamworkReporter.Models
{
    public class Account : DbEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}