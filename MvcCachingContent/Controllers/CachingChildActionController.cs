using System;
using System.Diagnostics;
using System.Web.Mvc;
using MvcCachingContent.Infrastructure;

namespace MvcCachingContent.Controllers
{
    public class CachingChildActionController : Controller
    {
        [OutputCache(CacheProfile = "cp1")]
        public ActionResult Index()
        {
            int counterValue = AppStateHelper.IncrementAndGet(AppStateKeys.IndexCounter);
            Debug.WriteLine($"IndexCounter: {counterValue}");
            return View((object)counterValue);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 60)]
        public PartialViewResult GetTime()
        {
            return PartialView((object)DateTime.Now.ToShortTimeString());
        }
    }
}