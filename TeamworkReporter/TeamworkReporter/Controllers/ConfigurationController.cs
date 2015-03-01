using System.Configuration;
using System.Web.Mvc;
using TeamworkReporter.Models;
using TeamworkReporter.Types;

namespace TeamworkReporter.Controllers
{
    public class ConfigurationController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Options()
        {
            var model = new OptionsViewModel
            {
                Account = Settings.Config.Account, 
                Token = Settings.Config.Token
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Options(OptionsViewModel model)
        {
            if (ModelState.IsValid)
            {
                Settings.Config.Account = model.Account;
                Settings.Config.Token = model.Token;
            }
            Settings.Storage.Save(Settings.Config);
            return RedirectToAction("Options");
        }
    }
}