namespace TeamworkReporter.Services.Permissions
{
    public interface IAuthenticationService
    {
        bool Validate(string usename, string password);
        void UpdatePassword(string userId, string password);
        string ResetPassword(string userId);

        /*
         * Login
         * Logout
         * RegisterUser
         * ResetPassword
         * RenderPassword
         */
    }
}
