using System.Web.Mvc;
using MadeUpStats.Services;
using MadeUpStats.Web.Models.Tag;

namespace MadeUpStats.Web.Controllers
{
    public class TagController : BaseController
    {
        private readonly ITagService tagService;

        public TagController(ITagService tagService, IUserInterfaceManager userInterfaceManager) : base(userInterfaceManager)
        {
            this.tagService = tagService;
        }

        public ActionResult Index(string tagName)
        {
            var model = new IndexViewModel();
            model.TagName = tagName;
            return View(model);
        }
    }
}