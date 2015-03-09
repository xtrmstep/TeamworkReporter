using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamworkReporter.TwClient;

namespace TeamworkReporter.TwClientTests
{
    [TestClass]
    public class ApiTest : ApiTestSetup
    {
        [TestCategory("Proxy Infrastructure")]
        [TestMethod]
        public void Authentication()
        {
        }

        [TestCategory("Proxy Infrastructure")]
        [TestMethod]
        public void Should_not_exceed_rate_limit()
        {
            // 120 requests per minute is allowable
            // 2 requests in a second
            for (var i = 1; i <= 240; i++)
            {
                ((IProxyProjects)Api).Get();
                
                // rate counter should grow with each request
                if (i <= 120)
                    Assert.AreEqual(i, Api.RequestsPerMinute);
                
                // the first request which exceeds the limit should stop processing pipe and wait to maintaint the rate limit
                if (i == 121)
                    Assert.IsTrue(Api.RequestWasDelayed);

                // rate counter should grow with each request BUT it should be started from 1
                if (i > 120)
                    Assert.AreEqual(i - 120, Api.RequestsPerMinute);
            }
        }
    }
}
