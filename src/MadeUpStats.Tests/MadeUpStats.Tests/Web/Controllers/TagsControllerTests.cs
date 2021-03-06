using System.Web.Mvc;
using MadeUpStats.Domain;
using MadeUpStats.Services;
using MadeUpStats.Web;
using MadeUpStats.Web.Controllers;
using MadeUpStats.Web.Models;
using Moq;
using MvcContrib.TestHelper;
using Xunit;

namespace MadeUpStats.Tests.Web.Controllers
{
    public class TagsControllerTests : ControllerTesterBase<TagsController>
    {
        protected Mock<ITagService> tagService;
        protected Mock<IStatService> statService;

        [Fact]
        public void TagsController_should_call_TagService_GetTags_on_Index()
        {
            var controller = GetController();

            controller.AllTags();

            tagService.Verify(x => x.GetTags(It.IsAny<int>()), Times.Once());
        }

        [Fact]
        public void TagsController_should_call_StatService_get_Stats_by_Tag_on_Index_with_string_arg()
        {
            var controller = GetController();

            controller.Index("chris");

            statService.Verify(x => x.GetStatsByTag(It.IsAny<Tag>()), Times.Once());
        }

        [Fact]
        public void TagsController_should_return_a_model_of_AllTagsDisplay_for_AllTags()
        {
            var controller = GetController();

            var result = controller.AllTags() as ViewResult;

            result.ViewData.Model.ShouldBeOfType<AllTagsDisplay>();
        }

        [Fact]
        public void TagsController_should_return_a_model_of_TagDisplay_for_Index()
        {
            var controller = GetController();

            var result = controller.Index("tag-name") as ViewResult;

            result.ViewData.Model.ShouldBeOfType<TagDisplay>();
        }

        [Fact]
        public void Index_with_null_tagName_should_Redirect_to_Home()
        {
            var controller = GetController();

            var result = controller.Index(null) as RedirectToRouteResult;

            result.ToAction<HomeController>(x => x.Index());
        }

        public override TagsController GetController()
        {
            statService = new Mock<IStatService>();
            tagService = new Mock<ITagService>();
            userInterfaceManager = new Mock<IUserInterfaceManager>();

            return new TagsController(tagService.Object, statService.Object, userInterfaceManager.Object);
        }
    }
}