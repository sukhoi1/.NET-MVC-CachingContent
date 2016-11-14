using System;
using System.Web;

namespace MvcCachingContent.Infrastructure
{
    public class CachingConfigurationLogic
    {
        /// <summary>
        /// It is better to detect controller and action rather than plain url (such as "/Home/Index", "/Home", "/" since routes are equal by default).
        /// </summary>
        public void DetectConfiguration(string url, HttpCachePolicyBase cachePolicy)
        {
            if (url == "/CodeCaching/Index")
            {
                cachePolicy.SetNoServerCaching();
                cachePolicy.SetCacheability(HttpCacheability.NoCache);
            }
            else
            {
                cachePolicy.SetExpires(DateTime.Now.AddSeconds(30));
                cachePolicy.SetCacheability(HttpCacheability.Public);
            }
        }
    }
}