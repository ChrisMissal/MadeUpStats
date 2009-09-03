using System;
using System.Linq;
using MadeUpStats.Data;
using MadeUpStats.Domain;
using MadeUpStats.Services;
using Moq;
using Xunit;

namespace MadeUpStats.Tests.Services
{
    public class StatServiceTests
    {
        [Fact]
        public void StatService_should_call_StatRepository_for_GetStatText()
        {
            const long id = 1;
            var statRepository = new Mock<IStatRepository>();

            new StatService(statRepository.Object).GetStat(id);

            statRepository.Verify(x => x.GetById(id), Times.Once(), "StatRepository was not called once.");
        }

        [Fact]
        public void StatService_should_be_able_to_create_a_Stat()
        {
            var statRepository = new Mock<IStatRepository>();
            var testStartTime = DateTime.Now;
            var author = new Author("Chris");
            const string description = "25% of cars go over 100mph.";

            var service = new StatService(statRepository.Object);
            var stat = service.CreateStat(author, "25% of", description);

            Assert.NotNull(stat);
            Assert.Equal("Chris", stat.Author.Name);
            Assert.Equal("25% of cars go over 100mph.", stat.Description);
            Assert.True(stat.CreateDate >= testStartTime);
        }

        [Fact]
        public void StatService_should_not_create_a_Stat_with_a_blank_description()
        {
            Assert.Throws<ArgumentException>(() => new StatService(null).CreateStat(null, null, string.Empty));
        }

        [Fact]
        public void StatService_should_not_create_a_Stat_with_a_null_description()
        {
            Assert.Throws<ArgumentNullException>(() => new StatService(null).CreateStat(null, null, null));
        }

        [Fact]
        public void StatService_should_be_able_to_Tag_a_Stat()
        {
            var tags = new[] {new Tag("one"), new Tag("two"), new Tag("three")};
            var stat = new Stat(null, null, null, DateTime.Now);

            Assert.Equal(0, stat.Tags.Count());

            new StatService(null).TagStat(stat, tags);

            Assert.Equal(3, stat.Tags.Count());
        }

        [Fact]
        public void StatService_should_not_tag_a_stat_with_a_null_tag_array()
        {
            var stat = new Stat(null, null, null, DateTime.Now);
            Assert.Throws<ArgumentNullException>(() => new StatService(null).TagStat(stat, null));
        }

        [Fact]
        public void StatService_should_not_tag_a_stat_with_an_array_containing_null_tags()
        {
            var stat = new Stat(null, null, null, DateTime.Now);
            var tagArray = new[] {new Tag("name"), null};
            Assert.Throws<ArgumentNullException>(() => new StatService(null).TagStat(stat, tagArray));
        }
    }
}