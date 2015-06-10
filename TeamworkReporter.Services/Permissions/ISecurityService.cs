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
        Profile Login(string usename, string password);
        void Logout(Token token);
        bool RegisterProfile(Profile profile);
        bool UpdatePassword(Profile profile, string newPassword);

        string ResetPassword(Profile profile);

        /*
         * RegisterUser
         * ResetPassword
         * RenderPassword
         */
    }
}
