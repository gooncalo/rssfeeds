using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;
using System.Xml;
using WebFeedsDomain.Domain;
using WebFeedsDomain.Interfaces;

namespace WebFeedsUI.Models
{
    public class FeedsManager
    {
        IFeedsProviderRepository _feedsProviderRepository = null;
        List<FeedsProvider> FeedsProviders
        {
            get
            {
                return _feedsProviderRepository.Providers.ToList();
            }
        }

        public List<FeedsReader> FeedsReaders { get; set; }

        public FeedsManager(IFeedsProviderRepository feedsProviderRepository)
        {
            _feedsProviderRepository = feedsProviderRepository;
            FeedsReaders = new List<FeedsReader>();
        }

        public void GetFeeds()
        {
            FeedsProviders.ForEach((x) =>
                {
                    FeedsReader reader = new FeedsReader(x);
                    reader.LoadFeeds();
                    FeedsReaders.Add(reader);                    
                });
        }

    }
}