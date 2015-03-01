using System.Web;
using System.Web.Mvc;

namespace TeamworkReporter.Types.Extensions
{
    public static class HtmlExtensions
    {
        public static IHtmlString LinkStylesheet(this HtmlHelper html, UrlHelper url, string uri)
        {
            var tb = new TagBuilder("link");
            tb.Attributes["rel"] = "stylesheet";
            tb.Attributes["href"] = url.Content(uri);
            return new MvcHtmlString(tb.ToString(TagRenderMode.SelfClosing));
        }
    }
}