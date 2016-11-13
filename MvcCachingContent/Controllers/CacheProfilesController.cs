using System.Diagnostics;
using System.Web.Mvc;
using MvcCachingContent.Infrastructure;

namespace MvcCachingContent.Controllers
{
    public class CacheProfilesController : Controller
    {
        [OutputCache(CacheProfile = "cp1")]
        public ActionResult Index()
        {
            int counterValue = AppStateHelper.IncrementAndGet(AppStateKeys.IndexCounter);
            Debug.WriteLine($"IndexCounter: {counterValue}");
            return View("~/Views/Shared/One.cshtml", (object)counterValue);
        }
    }
}