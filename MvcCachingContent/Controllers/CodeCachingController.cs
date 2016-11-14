using System;
using System.Diagnostics;
using System.Web.Mvc;
using MvcCachingContent.Infrastructure;

namespace MvcCachingContent.Controllers
{
    public class CodeCachingController : Controller
    {
        CachingConfigurationLogic cacheSettingsHelper = new CachingConfigurationLogic();

        public ActionResult Index()
        {
            cacheSettingsHelper.DetectConfiguration(Request.RawUrl, Response.Cache);

            int counterValue = AppStateHelper.IncrementAndGet(AppStateKeys.IndexCounter);
            Debug.WriteLine($"IndexCounter: {counterValue}");
            return View("~/Views/CachingChildAction/Index.cshtml", (object)counterValue);
        }

        [ChildActionOnly]
        public PartialViewResult GetTime()
        {
            return PartialView("~/Views/CachingChildAction/GetTime.cshtml", (object)DateTime.Now.ToLongTimeString());
        }
    }
}