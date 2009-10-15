using System;
using System.Web.Mvc;
using MadeUpStats.Framework;
using MadeUpStats.Services;
using MadeUpStats.Web.Models.Stat;
using MvcContrib;

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

        public ActionResult Index(long id)
        {
            var stat = statService.GetStat(id);
            if (stat == null)
                return RedirectToAction("Index", "Home");

            var model = new IndexViewModel();
            model.StatText = stat.Description;
            return View(model);
        }

        [AcceptVerbs(HttpVerbs.Get), ModelStateRebind, RebindTempData(typeof(CreateDataModel))]
        public ActionResult Create()
        {
            var model = new CreateViewModel();

            var createDataModel = ViewData.Model as CreateDataModel;
            model.CreateData = createDataModel ?? new CreateDataModel();

            return View(model);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(CreateDataModel createDataModel)
        {
            try
            {
                Validate.NotNull(createDataModel, "Stat data");

                var author = authorService.GetAuthor(createDataModel.Author);
                var stat = statService.CreateStat(author, createDataModel.Title, createDataModel.Description);

                if(!createDataModel.TagString.IsNullOrEmpty())
                {
                    var tags = tagService.CreateTags(createDataModel.TagString);
                    tags.ForEach(stat.AddTag);
                }
                statService.Update(stat);

                return RedirectToAction("Index", new { id = stat.Id });
            }
            catch (Exception ex)
            {
                AddMessage(ex.Message);
                TempData.Add(createDataModel);
            }

            return RedirectToAction("Create");
        }
    }
}
