using System;
using System.Web;

namespace MvcCachingContent.Infrastructure
{
    public static class AppStateHelper
    {
        public static int IncrementAndGet(AppStateKeys key)
        {
            string keyString = Enum.GetName(typeof(AppStateKeys), key);
            HttpApplicationState state = HttpContext.Current.Application;
            state[keyString] = (int)(state[keyString] ?? 0) + 1;
            return (int)state[keyString];
        }
    }
}