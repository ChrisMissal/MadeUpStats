using System.Web.Mvc;
using MadeUpStats.Domain;
using MadeUpStats.Framework;
using MadeUpStats.Services;
using MadeUpStats.Web.Models;

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

        public ActionResult AllTags()
        {
            var model = new AllTagsDisplay
            {
                Tags = tagService.GetTags(50)
            };
            return View(model);
        }

        public ActionResult Index(string tagName)
        {
            if (tagName.IsNullOrEmpty())
                return RedirectToAction<HomeController>(x => x.Index());

            var model = new TagDisplay
            {
                Name = tagName,
                Stats = statService.GetStatsByTag(new Tag(tagName))
            };
            return View(model);
        }
    }
}