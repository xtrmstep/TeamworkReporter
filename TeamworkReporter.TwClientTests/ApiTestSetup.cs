namespace TeamworkReporter.TwClientTests
{
    public class ApiTestSetup
    {
        protected TwClient.Api.TwClient Api;

        public ApiTestSetup()
        {
            Api = new TwClient.Api.TwClient
            {
                //email : twreporter@mail.ru
                //pass : qwerty
                SiteName = "xtrmtest1",
                ApiToken = "jones456silk"
            };
        }
    }
}