using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFeedsDomain.Enums;

namespace WebFeedsDomain.Domain
{
    public class FeedsProvider
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Feed> Feeds { get; set; }
        public FeedType Type { get; set; }
        public string Url { get; set; }
        public string MainPageImgUrl { get; set; }

        public FeedsProvider()
        {

        }
    }
}
