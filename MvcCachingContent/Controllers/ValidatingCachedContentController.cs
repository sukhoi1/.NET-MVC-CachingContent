using System;
using System.Diagnostics;
using System.Web;
using System.Web.Mvc;
using MvcCachingContent.Infrastructure;

namespace MvcCachingContent.Controllers
{
    public class ValidatingCachedContentController : Controller
    {
        CachingConfigurationLogic cacheSettingsHelper = new CachingConfigurationLogic();

        public ActionResult Index()
        {
            cacheSettingsHelper.DetectConfiguration(Request.RawUrl, Response.Cache);
            Response.Cache.AddValidationCallback(this.CheckCachedItem, Request.UserAgent);

            int counterValue = AppStateHelper.IncrementAndGet(AppStateKeys.IndexCounter);
            Debug.WriteLine($"IndexCounter: {counterValue}");
            return View("~/Views/CachingChildAction/Index.cshtml", (object)counterValue);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 20)]
        public PartialViewResult GetTime()
        {
            return PartialView("~/Views/CachingChildAction/GetTime.cshtml", (object)DateTime.Now.ToLongTimeString());
        }

        public void CheckCachedItem(HttpContext ctx, object data, ref HttpValidationStatus status)
        {
            status = data.ToString() == ctx.Request.UserAgent
                ? HttpValidationStatus.Valid
                : HttpValidationStatus.Invalid;
            Debug.WriteLine("Cache Status: " + status);
        }
    }
}