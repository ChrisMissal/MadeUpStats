namespace MadeUpStats.Web.Attributes
{
    public class HttpPostAttribute : HttpMethodAttribute
    {
        public HttpPostAttribute()
        {
            method = "post";
        }
    }
}