namespace MadeUpStats.Web.Attributes
{
    public class AllowAdminAttribute : AllowAttribute
    {
        public AllowAdminAttribute() : base(new[] {"Admin"})
        {
        }
    }
}