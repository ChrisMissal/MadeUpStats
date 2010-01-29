using System;
using System.Linq;
using MadeUpStats.Data;
using MadeUpStats.Domain;
using Moq;
using Xunit;

namespace MadeUpStats.Tests.Data
{
    public class StatRepositoryTests : StatHelper
    {
        private Mock<IObjectDatabase> objectDatabase;

        [Fact]
        public void SaveOrUpdate_should_call_ObjectDatabase_Store()
        {
            var stat = BlankStat;
            GetRepository().SaveOrUpdate(stat);
            objectDatabase.Verify(x => x.Store(stat));
        }

        [Fact]
        public void Delete_should_call_ObjectDatabase_Delete()
        {
            var stat = BlankStat;
            GetRepository().Delete(stat);
            objectDatabase.Verify(x => x.Delete(stat));
        }

        [Fact]
        public void GetAll_should_call_ObjectDatabase_QueryByExample()
        {
            GetRepository().GetAll();
            objectDatabase.Verify(x => x.QueryByExample<Stat>(It.IsAny<Stat>()));
        }

        [Fact]
        public void GetMostRecent_should_call_ObjectDatabase_Query()
        {
            GetRepository().GetMostRecent(0);
            objectDatabase.Verify(x => x.Query<Stat>());
        }

        [Fact]
        public void GetMostRecent_should_be_OrderedDescending_by_Stat_CreateDate()
        {
            var veryRecentStat = new Stat("", "", new Author("name"), DateTime.Now.AddDays(1));
            var repository = GetRepository();
            var stats = new[] { BlankStat, veryRecentStat, BlankStat };
            objectDatabase.Setup(x => x.Query<Stat>()).Returns(stats);

            var results = repository.GetMostRecent(stats.Length);

            results.First().ShouldBe(veryRecentStat);
        }

        [Fact]
        public void GetMostRecent_should_be_limited_to_the_count_provided()
        {
            var repository = GetRepository();
            var stats = new[] { BlankStat, BlankStat, BlankStat, BlankStat, BlankStat };
            objectDatabase.Setup(x => x.Query<Stat>()).Returns(stats);

            var results = repository.GetMostRecent(2);

            stats.Length.ShouldEqual(5);
            results.Count().ShouldEqual(2);
        }

        [Fact]
        public void GetByKey_should_call_ObjectDatabase_Query()
        {
            GetRepository().GetByKey("key");
            objectDatabase.Verify(x => x.Query<Stat>());
        }

        [Fact]
        public void GetByKey_returns_default_Stat_if_no_key_matches()
        {
            GetRepository().GetByKey("key").ShouldBe(default(Stat));
        }

        [Fact]
        public void GetByKey_returns_one_Stat_if_key_is_matched()
        {
            var repository = GetRepository();
            var stat = BlankStat.SetKey("key");
            var expectedId = stat.Id;
            objectDatabase.Setup(x => x.Query<Stat>()).Returns(new[] {stat});

            var result = repository.GetByKey("key");

            result.Id.ShouldEqual(expectedId);
        }

        [Fact]
        public void GetByTag_should_return_only_Stats_containing_Tags_with_matching_Keys()
        {
            var repository = GetRepository();

            var stat1 = BlankStat;
            stat1.AddTag(new Tag("name"));

            var stat2 = BlankStat;
            stat2.AddTag(new Tag("name"));

            var stat3 = BlankStat;
            stat3.AddTag(new Tag("blah"));

            objectDatabase.Setup(x => x.Query<Stat>()).Returns(new[] { stat1, stat2, stat3 });

            var results = repository.GetByTag(new Tag("name"));

            results.Count().ShouldEqual(2);
        }

        private StatRepository GetRepository()
        {
            objectDatabase = new Mock<IObjectDatabase>();
            return new StatRepository(objectDatabase.Object);
        }
    }
}