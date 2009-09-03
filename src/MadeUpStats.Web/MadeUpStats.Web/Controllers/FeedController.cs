using MadeUpStats.Web.Services;
using MvcContrib.ActionResults;

namespace MadeUpStats.Web.Controllers
{
    public class FeedController : BaseController
    {
        private readonly IFeedService feedService;

        public FeedController(IFeedService feedService, IUserInterfaceManager userInterfaceManager) : base(userInterfaceManager)
        {
            this.feedService = feedService;
        }

        public XmlResult Index()
        {
            var feed = feedService.CreateFeed();
            return new XmlResult(feed);
        }
    }
}