﻿using MvcCachingContent.Infrastructure;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Mvc;

namespace MvcState.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            int counterValue = AppStateHelper.IncrementAndGet(AppStateKeys.IndexCounter);
            Debug.WriteLine($"IndexCounter: {counterValue}");
            return View("~/Views/Shared/One.cshtml", (object)counterValue);
        }

        public ActionResult Many()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("Placeholder Property", "Placeholder Value");
            return View("~/Views/Shared/Many.cshtml", (object)data);
        }
    }
}