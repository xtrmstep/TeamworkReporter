using TeamworkReporter.Models;
using TeamworkReporter.Services.Types;

namespace TeamworkReporter.Services.Permissions
{
    /*
     * What is expected?
     * helper https://msdn.microsoft.com/en-us/library/webmatrix.webdata.websecurity(v=vs.111).aspx
     * membership http://www.codeproject.com/Articles/689801/Understanding-and-Using-Simple-Membership-Provider
     */
    public interface ISecurityService
    {
        string RenderPassword();
        
        bool Login(string userName, string password);
        void Logout();

        bool RequireAuthenticatedUser();
        bool RequireRoles(params string[] roles);
        bool RequirePermissions(params string[] permissions);
    }
}
