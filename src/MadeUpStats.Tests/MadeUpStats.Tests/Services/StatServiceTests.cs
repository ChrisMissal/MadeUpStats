using System;
using System.Linq;
using MadeUpStats.Data;
using MadeUpStats.Domain;
using MadeUpStats.Services;
using MadeUpStats.Tests.Fakes;
using Moq;
using Xunit;

namespace MadeUpStats.Tests.Services
{
    public class StatServiceTests
    {
        private Mock<IStatRepository> statRepository;

        [Fact]
        public void StatService_should_be_able_to_create_a_Key_by_a_Title()
        {
            const string title = "This is my Title";
            var service = GetService();

            var stat = service.CreateStat(new Author("name"), title, "description");

            stat.Key.ShouldEqual("this-is-my-title");
        }

        [Fact]
        public void StatService_should_know_if_StatRepository_contains_a_Stat_with_Key()
        {
            const string key = "key";
            var service = GetService();
            statRepository.Setup(x => x.GetByKey(key)).Returns(FakeStat.NewInstance);

            service.ContainsKey(key).ShouldBeTrue();
        }

        [Fact]
        public void StatService_should_know_if_StatRepository_doesnt_contain_a_Stat_with_Key()
        {
            const string key = "abc";
            var service = GetService();
            statRepository.Setup(x => x.GetByKey(key)).Returns(default(Stat));

            service.ContainsKey(key).ShouldBeFalse();
        }

        [Fact]
        public void StatService_should_call_StatRepository_for_GetStatText()
        {
            const string id = "key";

            GetService().GetStat(id);

            statRepository.Verify(x => x.GetByKey(id), Times.Once(), "StatRepository was not called once.");
        }

        [Fact]
        public void StatService_should_be_able_to_create_a_Stat()
        {
            var testStartTime = DateTime.Now;
            var author = new Author("Chris");
            const string description = "25% of cars go over 100mph.";

            var stat = GetService().CreateStat(author, "25% of", description);

            stat.ShouldNotBeNull();
            stat.Author.Name.ShouldEqual("Chris");
            stat.Description.ShouldEqual("25% of cars go over 100mph.");
            Assert.True(stat.CreateDate >= testStartTime);
        }

        [Fact]
        public void StatService_should_not_create_a_Stat_with_a_blank_description()
        {
            Assert.Throws<ArgumentException>(() => GetService().CreateStat(null, null, string.Empty));
        }

        [Fact]
        public void StatService_should_not_create_a_Stat_with_a_null_description()
        {
            Assert.Throws<ArgumentNullException>(() => GetService().CreateStat(null, null, null));
        }

        [Fact]
        public void StatService_should_be_able_to_Tag_a_Stat()
        {
            var tags = new[] {new Tag("one"), new Tag("two"), new Tag("three")};
            var stat = new Stat(null, null, null, DateTime.Now);

            stat.Tags.Count().ShouldEqual(0);

            GetService().TagStat(stat, tags);

            stat.Tags.Count().ShouldEqual(3);
        }

        [Fact]
        public void StatService_should_not_tag_a_stat_with_a_null_tag_array()
        {
            var stat = new Stat(null, null, null, DateTime.Now);
            Assert.Throws<ArgumentNullException>(() => GetService().TagStat(stat, null));
        }

        [Fact]
        public void StatService_should_not_tag_a_stat_with_an_array_containing_null_tags()
        {
            var stat = new Stat(null, null, null, DateTime.Now);
            var tagArray = new[] {new Tag("name"), null};
            Assert.Throws<ArgumentNullException>(() => GetService().TagStat(stat, tagArray));
        }

        [Fact]
        public void GetStatsByTag_should_call_StatRepository_GetByTag()
        {
            var tag = new Tag("beer");

            GetService().GetStatsByTag(tag);

            statRepository.Verify(x => x.GetByTag(tag));
        }

        private StatService GetService()
        {
            statRepository = new Mock<IStatRepository>();

            return new StatService(statRepository.Object);
        }
    }
}