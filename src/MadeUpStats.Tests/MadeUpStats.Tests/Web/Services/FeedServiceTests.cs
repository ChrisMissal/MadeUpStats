using System;
using System.Linq;
using MadeUpStats.Domain;
using MadeUpStats.Services;
using MadeUpStats.Web.Services;
using Moq;
using Xunit;

namespace MadeUpStats.Tests.Web.Services
{
    public class FeedServiceTests
    {
        [Fact]
        public void Feed_created_from_Service_should_have_recent_Stats()
        {
            var stat1 = new Stat("1", "2", new Author("3"), DateTime.Now);
            var stat2 = new Stat("4", "5", new Author("6"), DateTime.Now);
            var stat3 = new Stat("7", "8", new Author("9"), DateTime.Now);

            var stats = new[] { stat1, stat2, stat3 };
            var statService = new Mock<IStatService>();
            statService.Setup(x => x.GetMostRecentStats(25)).Returns(stats);

            var service = new FeedService(statService.Object);

            var feed = service.CreateFeed().GetFeed();

            Assert.Equal(stats.Count(), feed.Items.Count());
        }
    }
}