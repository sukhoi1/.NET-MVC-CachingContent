using System;
using System.Diagnostics;
using System.Web.Mvc;
using MvcCachingContent.Infrastructure;

namespace MvcCachingContent.Controllers
{
    public class DonutHoleController : Controller
    {
        public ActionResult Index()
        {
            int counterValue = AppStateHelper.IncrementAndGet(AppStateKeys.IndexCounter);
            Debug.WriteLine($"IndexCounter: {counterValue}");
            return View("~/Views/CachingChildAction/Index.cshtml", (object)counterValue);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 20)]
        public PartialViewResult GetTime()
        {
            return PartialView("~/Views/CachingChildAction/GetTime.cshtml", (object)DateTime.Now.ToShortTimeString());
        }
    }
}