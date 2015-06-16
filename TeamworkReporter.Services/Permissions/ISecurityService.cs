using TeamworkReporter.Models;

namespace TeamworkReporter.Services.Permissions
{
    /// <summary>
    /// Provides quick access to authentication and authorization routines for a current user
    /// </summary>
    public interface ISecurityService
    {
        /// <summary>
        /// Returns a rendered password
        /// </summary>
        /// <returns></returns>
        string RenderPassword();
        
        /// <summary>
        /// Authenticate a user by his credentials
        /// </summary>
        /// <remarks>
        /// The related cookie, user object and other related information should be loaded for further use
        /// </remarks>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        bool Login(string userName, string password);

        /// <summary>
        /// Remove from memory information about currently authenticated user
        /// </summary>
        void Logout();

        bool RequireAuthenticatedUser();
        bool RequireRoles(params string[] roles);
        bool RequirePermissions(params string[] permissions);
    }
}
