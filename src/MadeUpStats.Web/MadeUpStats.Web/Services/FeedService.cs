using System;
using MadeUpStats.Services;

namespace MadeUpStats.Web.Services
{
    public class FeedService : IFeedService
    {
        private readonly IStatService statService;
        private const string TITLE = @"Made Up Stats";
        private const string DESCRIPTION = @"The site that exists so that you can astound and amaze your friends with stuff that they 
		    didn't know. The obvious reason they don't know these things is because they're made 
		    up and just for fun.";

        public FeedService(IStatService statService)
        {
            this.statService = statService;
        }

        public Feed CreateFeed()
        {
            var recentStats = statService.GetMostRecentStats(25);
            var feed = new Feed(TITLE, DESCRIPTION, recentStats) {LastUpdatedTime = DateTime.Now};
            return feed;
        }
    }
}