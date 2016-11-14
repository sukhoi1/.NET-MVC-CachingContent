using System.Diagnostics;
using System.Web.Mvc;
using MvcCachingContent.Infrastructure;

namespace MvcCachingContent.Controllers
{
    public class CacheProfilesDisableController : Controller
    {
        [OutputCache(CacheProfile = "cp1-disable")]
        public ActionResult Index()
        {
            int counterValue = AppStateHelper.IncrementAndGet(AppStateKeys.IndexCounter);
            Debug.WriteLine($"IndexCounter: {counterValue}");
            return View((object)counterValue);
        }
    }
}