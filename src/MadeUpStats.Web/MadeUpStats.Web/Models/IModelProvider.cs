namespace MadeUpStats.Web.Models
{
    public interface IModelProvider
    {
        T GetModel<T>();
    }
}