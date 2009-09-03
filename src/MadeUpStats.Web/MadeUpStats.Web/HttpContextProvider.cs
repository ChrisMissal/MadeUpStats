using System.Web;

namespace MadeUpStats.Web
{
    public class HttpContextProvider : IHttpContextProvider
    {
        public HttpContextBase GetCurrentHttpContext()
        {
            return new HttpContextWrapper(HttpContext.Current);
        }

        public HttpSessionStateBase GetHttpSession()
        {
            return GetCurrentHttpContext().Session;
        }

        public HttpRequestBase GetHttpRequest()
        {
            return GetCurrentHttpContext().Request;
        }

        public HttpResponseBase GetHttpResponse()
        {
            return GetCurrentHttpContext().Response;
        }
    }
}