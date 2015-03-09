using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamworkReporter.Models;
using TeamworkReporter.Models.Timelogs;
using TeamworkReporter.TwClient;
using TeamworkReporter.Types;

namespace TeamworkReporter.Controllers
{
    public class ReportingController : Controller
    {
        public ActionResult Timelogs()
        {
            IProxyPeople apiPeople = new TwClient.Api.TwClient
            {
                SiteName = Settings.Config.Account,
                ApiToken = Settings.Config.Token
            };
            var people = apiPeople.Get();

            var model = new TimelogsViewModel
            {
                People = people.Select(p => new PersonViewModel
                {
                    FullName = string.Format("{0} {1}", p.FirstName, p.LastName),
                    Id = p.Id.ToString()
                }),
                Period = TimelogsPeriod.Daily,
                Grid = new TimelogsGridViewModel
                {
                    Headers = new[]
                    {
                        DateTime.Today.AddDays(-8).ToString("dd/MM/yy"),
                        DateTime.Today.AddDays(-7).ToString("dd/MM/yy"),
                        DateTime.Today.AddDays(-6).ToString("dd/MM/yy"),
                        DateTime.Today.AddDays(-5).ToString("dd/MM/yy"),
                        DateTime.Today.AddDays(-4).ToString("dd/MM/yy"),
                        DateTime.Today.AddDays(-3).ToString("dd/MM/yy"),
                        DateTime.Today.AddDays(-2).ToString("dd/MM/yy"),
                        DateTime.Today.AddDays(-1).ToString("dd/MM/yy"),
                        DateTime.Today.ToString("dd/MM/yy")
                    },
                    Hours = new Dictionary<string, IEnumerable<double>>
                    {
                        {"Alex Guid", new[] {1.5, 4, 3.6, 8, 8, 8,8,8,8}},
                        {"Alex Guid 2", new[] {1.23, 4.5, 3.67, 8, 8, 8,8,8,8}}
                    },
                    Totals = new Dictionary<string, double>
                    {
                        {"Alex Guid", 40},
                        {"Alex Guid 2", 40}
                    },
                }
            };

            return View(model);
        }
    }
}