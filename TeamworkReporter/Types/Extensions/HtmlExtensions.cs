using System;
using System.Diagnostics;
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

        /// <summary>
        /// Returns a version of the assembly in the starndard format "major-minor-date-build"
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static IHtmlString GetVersion(this HtmlHelper html)
        {
            var assemblyName = typeof (MvcApplication).Assembly.GetName();
            return new MvcHtmlString(assemblyName.Version.ToString());
        }

        /// <summary>
        /// Returns a copyrights
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static IHtmlString GetCopyrights(this HtmlHelper html)
        {
            var assembly = typeof (MvcApplication).Assembly;
            var fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            return new MvcHtmlString(fvi.LegalCopyright);
        }
    }
}