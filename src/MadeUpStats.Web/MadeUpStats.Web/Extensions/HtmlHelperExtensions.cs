using System;
using System.Web.Mvc;
using MadeUpStats.Framework;
using MadeUpStats.Web.Services;

namespace MadeUpStats.Web
{
    public static class HtmlHelperExtensions
    {
        public static string NiceDate(this HtmlHelper @this, DateTime dateTime)
        {
            return new DateFormatter().GetFormat(DateTime.Now, dateTime);
        }

        public static string CssUrl(this HtmlHelper @this, string location)
        {
            return "/content/css/{0}?_={1}".FormatWith(location, DateTime.Now.Ticks);
        }
    }
}