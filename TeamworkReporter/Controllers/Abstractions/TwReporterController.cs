using System.Web.Mvc;

namespace TeamworkReporter.Controllers.Abstractions
{
    public abstract class TwReporterController : Controller
    {
        protected readonly TempDataStorage tempStorage;

        protected TwReporterController()
        {
            tempStorage = new TempDataStorage(this);
        }

        public class TempDataStorage
        {
            private readonly TwReporterController _ctrl;

            internal TempDataStorage(TwReporterController ctrl)
            {
                _ctrl = ctrl;
            }

            public void Set<T>(T value)
            {
                _ctrl.TempData[typeof (T).Name] = value;
            }

            public T Get<T>()
            {
                var v = _ctrl.TempData[typeof (T).Name];
                return v != null ? (T) v : default (T);
            }
        }
    }
}