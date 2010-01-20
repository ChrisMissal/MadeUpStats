using System;
using System.Web.Mvc;
using MadeUpStats.Domain;
using MadeUpStats.Services;
using MadeUpStats.Web;
using MadeUpStats.Web.Controllers;
using MadeUpStats.Web.Models;
using Moq;
using Xunit;
using StatInput=MadeUpStats.Web.Models.StatInput;

namespace MadeUpStats.Tests.Web.Controllers
{
    public class StatControllerTests : ControllerTesterBase<StatController>
    {
        protected Mock<IStatService> statService;
        protected Mock<ITagService> tagService;
        protected Mock<IAuthorService> authorService;

        [Fact]
        public void StatController_should_AddErrorMessage_if_attempt_to_Create_stat_with_duplicate_key()
        {
            const string key = "existing-key";
            var controller = GetController();
            statService.Setup(x => x.ContainsKey(key)).Returns(true);

            controller.Create(new StatInput {Key = key});

            userInterfaceManager.Verify(x => x.AddMessage(It.IsRegex("A stat with a key of 'existing-key' already exists.")));
        }

        [Fact]
        public void StatController_should_redirect_to_the_HomeController_Index_if_stat_is_null_by_id()
        {
            var controller = GetController();
            const string key = "user";
            statService.Setup(x => x.GetStat(key)).Returns(() => null);

            var view = controller.Index(key) as RedirectToRouteResult;

            Assert.IsType(typeof (RedirectToRouteResult), view);
            Assert.Equal("Index", view.RouteValues["action"]);
            Assert.Equal("Home", view.RouteValues["controller"]);
        }

        [Fact]
        public void StatController_should_return_a_ViewResult_with_a_StatViewModel_for_Index()
        {
            var controller = GetController();
            const string key = "stat-key";
            statService.Setup(x => x.GetStat(key)).Returns(BlankStat);

            var view = controller.Index(key) as ViewResult;

            Assert.IsType(typeof(StatDisplay), view.ViewData.Model);
        }

        [Fact]
        public void StatController_should_return_a_StatViewModel_with_expected_StatText_for_Index()
        {
            var controller = GetController();
            const string expectedStatText = "MVC is fun";
            const string key = "some-key";
            statService.Setup(x => x.GetStat(key)).Returns(new Stat("", expectedStatText, null, DateTime.Now));

            var view = controller.Index(key) as ViewResult;
            var model = view.ViewData.Model as StatDisplay;

            Assert.Equal(expectedStatText, model.StatText);
        }

        [Fact]
        public void StatController_should_return_a_ViewResult_with_a_StatCreateModel_for_Create()
        {
            var controller = GetController();

            var view = controller.Create() as ViewResult;

            Assert.IsType(typeof (StatInput), view.ViewData.Model);
        }

        [Fact]
        public void StatController_should_call_StatService_getStatText_with_the_supplied_id_for_Index()
        {
            var controller = GetController();
            const string id = "key";

            controller.Index(id);

            statService.Verify(x => x.GetStat(id), Times.Once());
        }

        [Fact]
        public void StatController_should_call_AuthorService_GetAuthor_on_Create()
        {
            GetController().Create(new StatInput());

            authorService.Verify(x => x.GetLoggedInAuthor(), Times.Once());
        }

        [Fact]
        public void StatController_should_call_StatService_CreateStat_on_Create()
        {
            GetController().Create(new StatInput());

            statService.Verify(x => x.CreateStat(null, null, It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public void StatController_should_return_RedirectToRouteResult_on_Create()
        {
            var result = GetController().Create(new StatInput());

            result.ShouldBeOfType<RedirectToRouteResult>();
        }

        [Fact]
        public void StatController_should_not_call_TagService_if_TagString_is_empty()
        {
            var controller = GetController();
            var model = new StatInput { TagString = "" };

            controller.Create(model);

            tagService.Verify(x => x.CreateTags(model.TagString), Times.Never());
        }

        [Fact]
        public void StatController_should_call_TagService_if_TagString_is_not_empty()
        {
            var controller = GetController();
            var model = new StatInput{TagString = "something, another"};

            controller.Create(model);

            tagService.Verify(x => x.CreateTags(model.TagString), Times.Once());
        }

        public override StatController GetController()
        {
            statService = new Mock<IStatService>();
            authorService = new Mock<IAuthorService>();
            tagService = new Mock<ITagService>();
            userInterfaceManager = new Mock<IUserInterfaceManager>();

            return new StatController(statService.Object, authorService.Object, tagService.Object, userInterfaceManager.Object);
        }
    }
}