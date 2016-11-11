using System.Diagnostics;
using System.Web.Mvc;
using System.Web.UI;
using MvcCachingContent.Infrastructure;

namespace MvcCachingContent.Controllers
{
    public class VaryByParamController : Controller
    {
        [OutputCache(Duration = 30, VaryByHeader = "user-agent",
            VaryByParam = "name;city", Location = OutputCacheLocation.Any)]
        public ActionResult Index()
        {
            int counterValue = AppStateHelper.IncrementAndGet(AppStateKeys.IndexCounter);
            Debug.WriteLine($"IndexCounter: {counterValue}");
            return View("~/Views/Shared/One.cshtml", (object)counterValue);
        }
    }
}