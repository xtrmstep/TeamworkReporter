using System;

namespace TeamworkReporter.Models
{
    /// <summary>
    /// Represents an account
    /// </summary>
    public class Account : DbEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}