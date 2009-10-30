using System.Linq;
using MadeUpStats.Data;
using MadeUpStats.Domain;
using MadeUpStats.Services;
using Moq;
using Xunit;

namespace MadeUpStats.Tests.Services
{
    public class TagServiceTests
    {
        private const string PLAIN_TAG_NAME = "chris";

        protected Mock<ITagRepository> tagRepository;

        private TagService GetService()
        {
            if(tagRepository == null) tagRepository = new Mock<ITagRepository>();

            return new TagService(tagRepository.Object);
        }
        
        #region Creational tests

        [Fact]
        public void TagService_should_return_expected_number_of_tags_from_a_good_string()
        {
            var service = GetService();

            service.CreateTags("Chris, Missal").Count().ShouldEqual(2);
            service.CreateTags("Chris,M,Missal").Count().ShouldEqual(3);
            service.CreateTags("one, two', thr3e,, four five").Count().ShouldEqual(4);
        }

        [Fact]
        public void TagService_should_return_a_tag_without_certain_special_characters()
        {
            var service = GetService();

            service.CreateTags("Chris!").First().Name.ShouldEqual("chris");
            service.CreateTags("!@#$%^&*()t~`a_+}{\":<>?\\][=g").First().Name.ShouldEqual("tag");
            service.CreateTags("Don't repeat yourself!").First().Name.ShouldEqual("dont-repeat-yourself");
        }

        [Fact]
        public void TagService_should_return_null_when_creating_a_tag_from_null()
        {
            var tag = GetService().CreateTags(null).First();

            Assert.Equal(null, tag);
        }

        [Fact]
        public void TagService_should_return_null_when_creating_a_tag_from_empty_string()
        {
            var tag = GetService().CreateTags("").First();

            Assert.Equal(null, tag);
        }

        [Fact]
        public void TagService_should_create_an_expected_Tag()
        {
            const string tagString = PLAIN_TAG_NAME;

            var tag = GetService().CreateTags(tagString).First();

            Assert.Equal(tagString, tag.Name);
        }

        [Fact]
        public void TagService_should_not_create_a_tag_starting_with_a_space()
        {
            const string tagString = " dog";

            var tag = GetService().CreateTags(tagString).First();

            tag.Name.ShouldEqual("dog");
        }

        [Fact]
        public void TagService_should_not_create_a_tag_ending_with_a_space()
        {
            const string tagString = "cat ";

            var tag = GetService().CreateTags(tagString).First();

            tag.Name.ShouldEqual("cat");
        }

        #endregion

        #region Behavior tests

        [Fact]
        public void TagService_should_call_TagRepository_when_calling_DeleteTag()
        {
            var tag = new Tag(PLAIN_TAG_NAME);

            GetService().DeleteTag(tag);

            tagRepository.Verify(x => x.Delete(tag), Times.Once(), "Tag Repository was not called one time when it should have been.");
        }

        [Fact]
        public void TagService_should_call_TagRepository_when_calling_GetMostPopularTags()
        {
            GetService().GetMostPopularTags(1);

            tagRepository.Verify(x => x.GetMostPopularTags(1), Times.Once(), "Tag Repository was not called one time when it should have been.");
        }

        [Fact]
        public void TagService_should_call_TagRepository_when_calling_GetTags()
        {
            GetService().GetTags(25);

            tagRepository.Verify(x => x.GetTags(25), Times.Once(), "Tag Repository was not called one time when it should have been.");
        }

        #endregion
    }
}