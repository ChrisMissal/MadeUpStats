namespace MadeUpStats.Web.Attributes
{
    public class HttpGetAttribute : HttpMethodAttribute
    {
        public HttpGetAttribute()
        {
            method = "get";
        }
    }
}