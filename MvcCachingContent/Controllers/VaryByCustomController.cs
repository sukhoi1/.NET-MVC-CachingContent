using System.Diagnostics;
using System.Web.Mvc;
using System.Web.UI;
using MvcCachingContent.Infrastructure;

namespace MvcCachingContent.Controllers
{
    public class VaryByCustomController : Controller
    {
        [OutputCache(Duration = 30, 
            VaryByHeader = "user-agent",
            VaryByParam = "name;city", 
            VaryByCustom = "mobile",
            Location = OutputCacheLocation.Any)]
        public ActionResult Index(string name, string city)
        {
            int counterValue = AppStateHelper.IncrementAndGet(AppStateKeys.IndexCounter);
            Debug.WriteLine($"IndexCounter: {counterValue}");
            return View("~/Views/Shared/One.cshtml", (object)counterValue);
        }
    }
}