using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamworkReporter.Services.Configuration
{
    /// <summary>
    /// Provides system settings for the application
    /// </summary>
    /// <remarks>
    /// System settings are predefined and deployed with the package
    /// </remarks>
    public interface ISettingsService
    {
        string ConnectionString { get; }
    }
}
