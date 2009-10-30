using System;
using System.Web.Mvc;
using MadeUpStats.Framework;
using MadeUpStats.Services;
using MadeUpStats.Web.Models;
using MvcContrib;
using StatInput=MadeUpStats.Web.Models.StatInput;

namespace MadeUpStats.Web.Controllers
{
    public class StatController : BaseController
    {
        private readonly IAuthorService authorService;
        private readonly ITagService tagService;
        private readonly IStatService statService;

        public StatController(IStatService statService, IAuthorService authorService, ITagService tagService, IUserInterfaceManager userInterfaceManager) : base(userInterfaceManager)
        {
            this.statService = statService;
            this.authorService = authorService;
            this.tagService = tagService;
        }

        public ActionResult Index(string key)
        {
            var stat = statService.GetStat(key);
            if (stat == null)
                return RedirectToAction("Index", "Home");

            var model = new StatDisplay();
            model.StatText = stat.Description;
            return View(model);
        }

        [AcceptVerbs(HttpVerbs.Get), ModelStateRebind, RebindTempData(typeof(StatInput))]
        public ActionResult Create()
        {
            var createDataModel = ViewData.Model as StatInput;

            var model = createDataModel ?? new StatInput();

            return View(model);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(StatInput statInput)
        {
            try
            {
                Validate.NotNull(statInput, "Stat data");

                var author = authorService.GetAuthor(statInput.Author);

                if (statService.ContainsKey(statInput.Key))
                    throw new InvalidOperationException("A stat with a key of {0} already exists.".FormatWith(statInput.Key));

                var stat = statService.CreateStat(author, statInput.Title, statInput.Description);

                if(!statInput.TagString.IsNullOrEmpty())
                {
                    var tags = tagService.CreateTags(statInput.TagString);
                    tags.ForEach(stat.AddTag);
                }
                statService.Update(stat);

                return RedirectToAction("Index", new { id = stat.Id });
            }
            catch (Exception ex)
            {
                AddMessage(ex.Message);
                TempData.Add(statInput);
            }

            return RedirectToAction("Create");
        }
    }
}
