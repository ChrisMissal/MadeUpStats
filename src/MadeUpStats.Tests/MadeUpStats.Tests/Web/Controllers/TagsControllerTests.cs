using MadeUpStats.Domain;
using MadeUpStats.Services;
using MadeUpStats.Web;
using MadeUpStats.Web.Controllers;
using Moq;
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

            controller.Index();

            tagService.Verify(x => x.GetTags(It.IsAny<int>()), Times.Once());
        }

        [Fact]
        public void TagsController_should_call_StatService_get_Stats_by_Tag_on_Index_with_string_arg()
        {
            var controller = GetController();

            controller.Index("chris");

            statService.Verify(x => x.GetStatsByTag(It.IsAny<Tag>()), Times.Once());
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