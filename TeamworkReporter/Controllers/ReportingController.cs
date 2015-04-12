using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
        struct SessionTags
        {
            public const string SelectedPeople = "SelectedPeople";
            public const string Period = "Period";
        }

        [HttpGet]
        public ActionResult Timelogs()
        {
            var sesSelectedPeople = Session[SessionTags.SelectedPeople];
            var sesPeriod = Session[SessionTags.Period];

            TimelogsViewModel model;
            try
            {
                #region get all people
                IProxyPeople apiPeople = new TwClient.Api.TwClient
                            {
                                SiteName = Settings.Config.Account,
                                ApiToken = Settings.Config.Token
                            };
                var people = apiPeople.Get(); 
                #endregion

                var selectedPeople = (sesSelectedPeople as IEnumerable<PersonViewModel>) ?? Enumerable.Empty<PersonViewModel>();
                var timelogsPeriod = sesPeriod != null ? (TimelogsPeriod)sesPeriod : TimelogsPeriod.Daily;
                var periods = PeriodsHelper.GetPeriods(DateTime.Now, timelogsPeriod);
                model = new TimelogsViewModel
                {
                    People = people.Select(p => new PersonViewModel
                    {
                        FullName = string.Format("{0} {1}", p.FirstName, p.LastName),
                        Id = p.Id.ToString(),
                        Selected = selectedPeople.Any(sp => sp.Id == p.Id.ToString())
                    }),
                    SelectedPeople = selectedPeople,
                    Grid = new TimelogsGridViewModel
                    {
                        Headers = periods.ConvertToNames(timelogsPeriod)
                    }
                };

                GetUserTimelogs(model, periods);
            }
            catch (Exception)
            {
                model = new TimelogsViewModel();
            }

            return View(model);
        }

        private void GetUserTimelogs(TimelogsViewModel model, DateTime[] periods)
        {
            if (model.SelectedPeople != null)
                foreach (var person in model.SelectedPeople)
                {
                    model.Grid.Hours.Add(person.FullName, new[] {1, 2, 3, 4, 5, 6, 7, 8, 9d});
                    model.Grid.Totals.Add(person.FullName, 10d);
                }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Timelogs(TimelogsViewModel options)
        {
            options.SelectedPeople = options.SelectedPeople ?? new PersonViewModel[] {};

            Session[SessionTags.SelectedPeople] = options.SelectedPeople;
            Session[SessionTags.Period] = options.Period;

            var periods = PeriodsHelper.GetPeriods(DateTime.Now, options.Period);
            options.Grid = new TimelogsGridViewModel
            {
                Headers = periods.ConvertToNames(options.Period)
            };
            GetUserTimelogs(options, periods);

            return PartialView("_TimelogGrid", options);
        }
    }
}