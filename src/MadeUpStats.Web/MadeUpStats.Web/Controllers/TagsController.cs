using System.Web.Mvc;
using MadeUpStats.Domain;
using MadeUpStats.Services;
using MadeUpStats.Web.Models.Tag;

namespace MadeUpStats.Web.Controllers
{
    public class TagsController : BaseController
    {
        private readonly ITagService tagService;
        private readonly IStatService statService;

        public TagsController(ITagService tagService, IStatService statService, IUserInterfaceManager userInterfaceManager) : base(userInterfaceManager)
        {
            this.tagService = tagService;
            this.statService = statService;
        }

        public ActionResult Index()
        {
            var model = new TagDisplay();
            model.Tags = tagService.GetTags(50);
            return View(model);
        }

        public ActionResult Index(string tagName)
        {
            var model = new TagDisplay();
            model.TagName = tagName;
            model.Stats = statService.GetStatsByTag(new Tag(tagName));
            return View(model);
        }
    }
}