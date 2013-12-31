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

        public string ImageUrl 
        {
            get { return _feedsProvider.MainPageImgUrl; } 
        
        }

        public FeedsProvider FeedsProvider 
        {
            get { return _feedsProvider; }         
        }

        public string Name 
        {
            get { return _feedsProvider.Name; }         
        }

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
                if (string.IsNullOrWhiteSpace(_feedsProvider.MainPageImgUrl))
                    _feedsProvider.MainPageImgUrl = blogFeed.ImageUrl.AbsoluteUri;

                foreach (var item in blogFeed.Items)
                {
                    Feed feed = new Feed()
                    {
                        Title = item.Title.Text,
                        Description = item.Summary.Text,
                        Link = item.Links.FirstOrDefault().Uri.AbsoluteUri
                    };

                    int index = feed.Description.IndexOf("<");
                    if(index != -1)
                        feed.Description = feed.Description.Remove(index);

                    _feeds.Add(feed);
                }

            }

            return _feeds;
        }

    }
}