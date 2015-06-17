using System;
using System.Data.Entity;
using TeamworkReporter.Models;

namespace TeamworkReporter.DataContext
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITwrDbContext : IDisposable
    {
        void Commit();

        IDbSet<Account> Accounts { get; set; }
        IDbSet<Role> Roles { get; set; }
        IDbSet<Permission> Permissions { get; set; }
        IDbSet<AppSetting> AppSettings { get; set; }
        IDbSet<IntegrationSetting> IntegrationSettings { get; set; }
        IDbSet<TimelogsProvider> TimelogsProviders { get; set; }
    }
}
