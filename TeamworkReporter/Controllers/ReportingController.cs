using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamworkReporter.Models;
using TeamworkReporter.Models.Timelogs;

namespace TeamworkReporter.Controllers
{
    public class ReportingController : Controller
    {
        public ActionResult Timelogs()
        {
            var model = new TimelogsViewModel
            {
                People = new[]
                {
                    new PersonViewModel {FullName = "Alex Guid", Id = Guid.NewGuid().ToString()},
                    new PersonViewModel {FullName = "Alex Guid 2", Id = Guid.NewGuid().ToString()}
                },
                Period = TimelogsPeriod.Daily,
                Grid = new TimelogsGridViewModel
                {
                    Headers = new[]
                    {
                        DateTime.Today.AddDays(-2).ToShortDateString(),
                        DateTime.Today.AddDays(-1).ToShortDateString(),
                        DateTime.Today.ToShortDateString()
                    },
                    Hours = new Dictionary<string, IEnumerable<double>>
                    {
                        {"Alex Guid", new[] {1.5, 4, 3.6}},
                        {"Alex Guid 2", new[] {1.23, 4.5, 3.67}}
                    }
                }
            };

            return View(model);
        }
    }
}