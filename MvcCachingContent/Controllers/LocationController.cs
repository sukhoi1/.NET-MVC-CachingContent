using System.Diagnostics;
using System.Web.Mvc;
using System.Web.UI;
using MvcCachingContent.Infrastructure;

namespace MvcState.Controllers
{
    public class LocationController : Controller
    {
        [OutputCache(Duration = 30, Location = OutputCacheLocation.Downstream)]
        public ActionResult Index()
        {
            int counterValue = AppStateHelper.IncrementAndGet(AppStateKeys.IndexCounter);
            Debug.WriteLine($"IndexCounter: {counterValue}");
            return View("~/Views/Shared/One.cshtml", (object)counterValue);
        }
    }
}