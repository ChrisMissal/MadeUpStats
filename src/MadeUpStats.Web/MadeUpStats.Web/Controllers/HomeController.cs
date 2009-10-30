using System.Web.Mvc;
using MadeUpStats.Domain;
using MadeUpStats.Services;
using MadeUpStats.Web.Models;
using MadeUpStats.Web.Services;

namespace MadeUpStats.Web.Controllers
{
    [HandleError]
    public class HomeController : BaseController
    {
        private readonly IStatService statService;
        private readonly IMapper mapper;

        public HomeController(IStatService statService, IMapper mapper, IUserInterfaceManager userInterfaceManager) : base(userInterfaceManager)
        {
            this.statService = statService;
            this.mapper = mapper;
        }

        public ActionResult Index()
        {
            var stats = statService.GetMostRecentStats(5);

            var model = new HomeDisplay();
            model.FeaturedStats = mapper.Map<Stat, StatDisplay>(stats);

            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Information()
        {
            return View();
        }
    }
}