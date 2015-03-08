using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TeamworkReporter.Types.Extensions.Tests
{
    [TestClass]
    public class HtmlExtensionsTests
    {
        private static UrlHelper urlHelper;
        private static HtmlHelper htmlHelper;

        [ClassInitialize]
        public static void TestSuiteSetup(TestContext context)
        {
            var requestContext = new RequestContext(new Mock<HttpContextBase>().Object, new RouteData());
            urlHelper = new UrlHelper(requestContext);
            var viewContext = new ViewContext();
            var viewDataContainer = new Mock<IViewDataContainer>().Object;
            htmlHelper = new HtmlHelper(viewContext, viewDataContainer);
        }

        [TestMethod]
        public void LinkStylesheet_should_render_well_formatted_link_tag()
        {
            const string url = "stylesheetUrl";
            const string extepected = "<link href=\"" + url + "\" rel=\"stylesheet\" />";
            var actual = htmlHelper.LinkStylesheet(urlHelper, url);
            Assert.AreEqual(extepected, actual.ToString());
        }
    }
}