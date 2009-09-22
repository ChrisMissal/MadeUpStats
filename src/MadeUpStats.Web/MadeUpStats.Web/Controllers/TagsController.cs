using System;
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
            var model = new IndexViewModel();
            model.Tags = tagService.GetTags(50);
            return View(model);
        }

        public ActionResult Index(string tagString)
        {
            var model = new IndexViewModel();
            model.TagName = tagString;
            model.Stats = statService.GetStatsByTag(new Tag(tagString));
            return View(model);
        }
    }
}