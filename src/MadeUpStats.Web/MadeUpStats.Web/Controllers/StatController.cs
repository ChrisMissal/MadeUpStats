using System;
using System.Web.Mvc;
using MadeUpStats.Domain;
using MadeUpStats.Framework;
using MadeUpStats.Services;
using MadeUpStats.Web.Attributes;
using MadeUpStats.Web.Models;
using MadeUpStats.Web.Services;
using MvcContrib;

namespace MadeUpStats.Web.Controllers
{
    public class StatController : BaseController
    {
        private readonly IAuthorService authorService;
        private readonly ITagService tagService;
        private readonly IMapper mapper;
        private readonly IStatService statService;

        public StatController(IStatService statService, IAuthorService authorService, ITagService tagService, IUserInterfaceManager userInterfaceManager, IMapper mapper) : base(userInterfaceManager)
        {
            this.statService = statService;
            this.authorService = authorService;
            this.tagService = tagService;
            this.mapper = mapper;
        }

        public ActionResult Index(string key)
        {
            var stat = statService.GetStat(key);
            if (stat == null)
                return RedirectToAction<HomeController>(x => x.Index());

            var model = mapper.Map<Stat, StatDisplay>(stat);

            return View(model);
        }

        [AllowAdmin, HttpGet, ModelStateRebind, RebindTempData(typeof(StatInput))]
        public ActionResult Create()
        {
            var model = ViewData.Model as StatInput ?? new StatInput();

            return View(model);
        }

        [AllowAdmin, HttpPost]
        public ActionResult Create(StatInput statInput)
        {
            try
            {
                Validate.NotNull(statInput, "statInput");

                var author = authorService.GetLoggedInAuthor();

                if (statService.ContainsKey(statInput.Key))
                    throw new InvalidOperationException("A stat with a key of '{0}' already exists.".FormatWith(statInput.Key));

                var stat = statService.CreateStat(author, statInput.Title, statInput.Description);

                if(!statInput.TagString.IsNullOrEmpty())
                {
                    var tags = tagService.CreateTags(statInput.TagString);
                    tags.ForEach(stat.AddTag);
                }
                statService.Update(stat);

                return RedirectToAction<StatController>(x => x.Index(null), new{key = stat.Key});
            }
            catch (Exception ex)
            {
                AddMessage(ex.Message);
                TempData.Add(statInput);
            }

            return RedirectToAction<StatController>(x => x.Create());
        }
    }
}
