using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamworkReporter.Models;
using TeamworkReporter.Services.Configuration;
using TeamworkReporter.Services.Permissions;

namespace TeamworkReporter.DataContext
{
    public class SecurityService : ISecurityService
    {
        private ISettingsService _settingsService;
        private IDbSet<Account> _accounts;

        public SecurityService(ISettingsService settingsService, IDbSet<Account> accounts)
        {
            _settingsService = settingsService;
        }

        public string RenderPassword()
        {
            throw new NotImplementedException();
        }

        public bool Login(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }

        public bool RequireAuthenticatedUser()
        {
            throw new NotImplementedException();
        }

        public bool RequireRoles(params string[] roles)
        {
            throw new NotImplementedException();
        }

        public bool RequirePermissions(params string[] permissions)
        {
            throw new NotImplementedException();
        }
    }
}
