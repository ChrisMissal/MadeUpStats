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
            var stat1 = new Stat(null, null, null, DateTime.Now);
            var stat2 = new Stat(null, null, null, DateTime.Now);
            var stat3 = new Stat(null, null, null, DateTime.Now);

            var stats = new[] { stat1, stat2, stat3 };
            var statService = new Mock<IStatService>();
            statService.Setup(x => x.GetMostRecentStats(25)).Returns(stats);

            var service = new FeedService(statService.Object);

            var feed = service.CreateFeed().GetFeed();

            Assert.Equal(stats.Count(), feed.Items.Count());
        }
    }
}