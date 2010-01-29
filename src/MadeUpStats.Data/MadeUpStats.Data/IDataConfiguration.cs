namespace MadeUpStats.Data
{
    public interface IDataConfiguration
    {
        string Path { get; }
    }

    public class DataConfiguration : IDataConfiguration
    {
        public string Path
        {
            get { return "C:\\temp\\data.yap"; }
        }
    }
}