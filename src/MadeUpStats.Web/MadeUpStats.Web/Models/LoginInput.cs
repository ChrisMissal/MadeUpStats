namespace MadeUpStats.Web.Models
{
    public class LoginInput : InputBase
    {
        public virtual string UserName { get; set; }

        public virtual string Password { get; set; }
    }
}