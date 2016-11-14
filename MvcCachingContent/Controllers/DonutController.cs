using System;
using System.Diagnostics;
using System.Web.Mvc;
using DevTrends.MvcDonutCaching;
using MvcCachingContent.Infrastructure;

namespace MvcCachingContent.Controllers
{
    /// <summary>
    /// https://github.com/moonpyk/mvcdonutcaching
    /// The package adds several overloads to the built-in Html.Action HTML helper.
    /// The extra parameter in each overload is named excludeFromParentCache.
    /// @Html.Action("Login", "Account", true)
    /// </summary>
    public class DonutController : Controller
    {
        [DonutOutputCache(Duration = 20)]
        public ActionResult Index()
        {
            int counterValue = AppStateHelper.IncrementAndGet(AppStateKeys.IndexCounter);
            Debug.WriteLine($"IndexCounter: {counterValue}");
            return View((object)counterValue);
        }

        [ChildActionOnly]
        public PartialViewResult GetTime()
        {
            return PartialView("~/Views/CachingChildAction/GetTime.cshtml", (object)DateTime.Now.ToLongTimeString());
        }
    }
}