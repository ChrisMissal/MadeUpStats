using MadeUpStats.Domain;

namespace MadeUpStats.Web.Models.Stat
{
    public class CreateViewModel : ViewModel
    {
        public CreateDataModel CreateData { get; set; }
        public Author Author { get; set; }
    }
}