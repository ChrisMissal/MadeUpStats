using System.Web;

namespace MadeUpStats.Web
{
    public interface IHttpContextProvider
    {
        HttpContextBase GetCurrentHttpContext();
        HttpSessionStateBase GetHttpSession();
        HttpRequestBase GetHttpRequest();
        HttpResponseBase GetHttpResponse();
    }
}