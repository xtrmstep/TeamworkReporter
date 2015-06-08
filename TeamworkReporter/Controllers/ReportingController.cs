using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TeamworkReporter.Controllers.Abstractions;
using TeamworkReporter.Models;
using TeamworkReporter.Models.Timelogs;
using TeamworkReporter.TwClient;
using TeamworkReporter.Types;

namespace TeamworkReporter.Controllers
{
    public class ReportingController : AuthorizedController
    {
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
                var timelogsPeriod = sesPeriod != null ? (TimelogsPeriod) sesPeriod : TimelogsPeriod.Daily;
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
                        Headers = periods.ConvertToNames(timelogsPeriod, DateTime.Now)
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
            if (model.SelectedPeople == null) return;

            IProxyTimeTracking apiTimeTracking = new TwClient.Api.TwClient
            {
                SiteName = Settings.Config.Account,
                ApiToken = Settings.Config.Token
            };
            foreach (var person in model.SelectedPeople)
            {
                var personId = int.Parse(person.Id);
                // get all timelogs for all people
                var timelogs = apiTimeTracking.Get(periods.First(), DateTime.Today, personId);

                var personTotalMinutes = timelogs.Sum(t => t.Hours * 60 + t.Minutes);
                model.Grid.Totals.Add(person.FullName, Math.Round(personTotalMinutes/60d, 2));

                var timelogsByPeriod = new List<double>();
                foreach (var period in periods)
                {
                    var totalMinutes = timelogs
                        .Where(timelog => DateTime.Parse(timelog.Date).Date == period)
                        .Sum(timelog => timelog.Hours*60 + timelog.Minutes);
                    var periodTotal = Math.Round(totalMinutes/60d, 2);
                    timelogsByPeriod.Add(periodTotal);
                }
                model.Grid.Hours.Add(person.FullName, timelogsByPeriod);
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
                Headers = periods.ConvertToNames(options.Period, DateTime.Now)
            };
            GetUserTimelogs(options, periods);

            return PartialView("_TimelogGrid", options);
        }

        private struct SessionTags
        {
            public const string SelectedPeople = "SelectedPeople";
            public const string Period = "Period";
        }
    }
}