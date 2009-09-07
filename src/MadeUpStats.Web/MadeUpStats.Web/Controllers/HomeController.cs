using System.Web.Mvc;
using MadeUpStats.Services;
using MadeUpStats.Web.Models.Home;

namespace MadeUpStats.Web.Controllers
{
    [HandleError]
    public class HomeController : BaseController
    {
        private readonly IStatService statService;

        public HomeController(IStatService statService, IUserInterfaceManager userInterfaceManager) : base(userInterfaceManager)
        {
            this.statService = statService;
        }

        public ActionResult Index()
        {
            var model = new IndexViewModel();
            model.FeaturedStats = statService.GetMostRecentStats(5);
            return View(model);
        }

        public ActionResult About()
        {
            var model = new AboutViewModel();
            return View(model);
        }

        public ActionResult Information()
        {
            var model = new InformationViewModel();
            return View(model);
        }
    }
}