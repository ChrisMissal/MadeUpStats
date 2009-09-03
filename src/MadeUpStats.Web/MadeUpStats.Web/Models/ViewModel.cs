namespace MadeUpStats.Web.Models
{
    public abstract class ViewModel
    {
        public virtual string GetViewName()
        {
            return GetType().Name.Replace("ViewModel", string.Empty);
        }
    }
}