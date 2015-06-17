using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamworkReporter.Models;

namespace TeamworkReporter.DataContext
{
    public class TwReporterContext : DbContext, ITwrDbContext
    {
        public static readonly Guid NotStoredId = new Guid("00000001-0002-0003-0004-000000000005");

        public TwReporterContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer<TwReporterContext>(null);
            if (!Database.Exists())
            {
                // Create the SimpleMembership database without Entity Framework migration schema
                ((IObjectContextAdapter)this).ObjectContext.CreateDatabase();
            }
        }

        public IDbSet<Account> Accounts { get; set; }
        public IDbSet<AppSetting> AppSettings { get; set; }
        public IDbSet<IntegrationSetting> IntegrationSettings { get; set; }
        public IDbSet<Permission> Permissions { get; set; }
        public IDbSet<Role> Roles { get; set; }
        public IDbSet<TimelogsProvider> TimelogsProviders { get; set; }

        public void Commit()
        {
            SaveChanges();
        }
    }
}
