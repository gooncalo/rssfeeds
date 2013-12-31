using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;
using System.Xml;
using WebFeedsDomain.Domain;
using WebFeedsDomain.Enums;

namespace WebFeedsUI.Models
{
    public class FeedsReader
    {
        private FeedsProvider _feedsProvider;
        private List<Feed> _feeds = new List<Feed>();

        public List<Feed> Feeds 
        {
            get { return _feeds; }
            set
            {
                _feeds = value;
            }
        }

        public FeedType Type 
        { 
            get { return _feedsProvider.Type; } 
             
        }

        public FeedsReader(FeedsProvider feedsProvider)
        {
            _feedsProvider = feedsProvider;
        }

        public List<Feed> LoadFeeds()
        {
            string request = _feedsProvider.Url;
            using (XmlReader xmlReader = XmlReader.Create(request))
            {
                SyndicationFeed blogFeed = SyndicationFeed.Load(xmlReader);
                foreach (var item in blogFeed.Items)
                {
                    Feed feed = new Feed()
                    {
                        Title = item.Title.Text,
                        Description = item.Summary.Text,
                        Link = item.Links.FirstOrDefault().Uri.AbsoluteUri
                    };

                    _feeds.Add(feed);
                }

            }

            return _feeds;
        }

    }
}