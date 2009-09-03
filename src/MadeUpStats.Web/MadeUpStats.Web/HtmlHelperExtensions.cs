using System;
using System.Web.Mvc;
using MadeUpStats.Framework;

namespace MadeUpStats.Web
{
    public static class HtmlHelperExtensions
    {
        public static string CssUrl(this HtmlHelper @this, string location)
        {
            return "/Content/css/{0}?_={1}".FormatWith(location, DateTime.Now.Ticks);
        }
    }
}