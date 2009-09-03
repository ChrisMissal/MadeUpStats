using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using MadeUpStats.Domain;
using MadeUpStats.Framework;

namespace MadeUpStats.Web
{
    public class Feed
    {
        private const string BASE_APPLICATION_DOMAIN = "http://www.madeupstats.com";
        private static readonly Uri baseUri = new Uri(BASE_APPLICATION_DOMAIN);
        private readonly SyndicationFeed syndicationFeed;

        public Feed(string title, string description, IEnumerable<Stat> stats)
        {
            var statItems = new List<SyndicationItem>();
            stats.ForEach(item => statItems.Add(new SyndicationItem(item.Title, item.Description, GetUri(item))));
            syndicationFeed = new SyndicationFeed
                       {
                               Title = new TextSyndicationContent(title),
                               Description = new TextSyndicationContent(description),
                               Items = statItems
                       };
        }

        public DateTimeOffset LastUpdatedTime
        {
            get { return syndicationFeed.LastUpdatedTime; }
            set { syndicationFeed.LastUpdatedTime = value; }
        }

        public SyndicationFeed GetFeed()
        {
            return syndicationFeed;
        }

        private static Uri GetUri(Stat stat)
        {
            return new Uri("{0}/Stat/{1}".FormatWith(baseUri, stat.Id));
        }
    }
}